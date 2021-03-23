namespace Microservice3
open Application1.AppTypes
open Microservice3.Types
module Main=

  /// Take command-line args and whatever else and make a configuration for the app
  let emptyAppDataTransfer:UniversalAppDataStream={
    StreamName=""
    DataLines=Seq.empty
    }
  let getAppconfig=emptyAppDataTransfer
  let defaultApplication1Config=Seq.empty
  let defaultApp1Microservice3Config =Seq.empty

  let getMicroservice3Configuration (args:string[])=Seq.empty
  let getAppConfig (args:string[])=Seq.empty

  let getConfig:GetConfigurationFunction =
    (fun (args:string[])->defaultApp1Microservice3Config)

  let getIncomingStream:GetIncomingStreamFunction=
    (fun (appConfig)->defaultApp1Microservice3Config,emptyAppDataTransfer)

  let processIncomingData:ProcessIncomingDataFunction =
    (fun (appConfig,incomingDataStream)->(appConfig,""))

  let translateIncomingDataToBusinessData:TranslateIncomingDataToBusinessTypesFunction =
    (fun (appConfig,incomingDataReceivedWithoutError)->(appConfig,""))

  let validateBusinessDataWithItself:ValidateBusinessDataWithItselfFunction=
    (fun (appConfig,businessStuff)->(appConfig,""))

  let processBusinessData:ProcessDataFunction=
    (fun (appConfig,validatedBusinessTypesToDoStuffWith)->(appConfig,""))

  let createOutgoingStreams:CreateOutgoingStreamsFromProcessedDataFunction=
    (fun (appConfig,processedBusinessData)->(appConfig,""))

  let returnTransformedDataToCaller:processOutgoingStreamsAndReturnToCallerFunction=
    (fun (appConfig,outgoingStreams)->
      (appConfig,emptyAppDataTransfer)) // FROM OS WRITE DATA CALL

  let persistTransformedData:ProcessOutgoingStreamsToPersistenceLayerFunction=
    (fun (appConfig,outgoingStreams)->0) // FROM OS WRITE DATA CALL

  /// the heart of the microservice:
  /// a pure data functional transform
  /// this is what's called from any
  /// external supervisor/flow control
  /// TLA+ app etc that wants to organize
  /// the functionality
  /// You can also just assemble these from
  /// multiple microservices to create a monolith
  let runInternally:RunInternallyFunction=
    (fun (argv,incomingsStreamsFromOS)->
    getConfig argv
    |> getIncomingStream
    |> processIncomingData
    |> translateIncomingDataToBusinessData
    |> validateBusinessDataWithItself
    |> processBusinessData
    |> createOutgoingStreams
    |> returnTransformedDataToCaller)

  /// app Flow
  /// this is what happens from the command line
  /// the data can come and go from wherever the
  /// OS wants: files, message quques, etc
  let run(argv, incomingStreamsFromOS:UniversalAppDataStream):int =
    runInternally (argv,incomingStreamsFromOS)
    |> persistTransformedData

  [<EntryPoint>]
  let main argv =
    let defaultIncomingSteamsFromOS=emptyAppDataTransfer
    run (argv,defaultIncomingSteamsFromOS)