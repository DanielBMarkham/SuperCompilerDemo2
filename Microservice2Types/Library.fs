namespace Microservice2
open Application1.AppTypes
module Types=
  type Microservice2Config=UniversalMicroserviceConfig
  type GetConfigurationFunction=string[]->Microservice2Config

  type GetIncomingStreamFunction=Microservice2Config->Microservice2Config*UniversalAppDataStream

  // Dummy Type
  type IncomingData=string
  type ProcessIncomingDataFunction=Microservice2Config*UniversalAppDataStream->Microservice2Config*IncomingData

  // Dummy type
  type BusinessTypes=string
  type TranslateIncomingDataToBusinessTypesFunction=Microservice2Config*IncomingData->Microservice2Config*BusinessTypes

  type ValidatedBusinessDataType=string
  type ValidateBusinessDataWithItselfFunction=Microservice2Config*BusinessTypes->Microservice2Config*ValidatedBusinessDataType

// more dummy types
  type  ProcessedBusinessData=string
  type ProcessDataFunction=Microservice2Config*ValidatedBusinessDataType->Microservice2Config*ProcessedBusinessData

  //dummy
  type OutgoingStreams=string
  type CreateOutgoingStreamsFromProcessedDataFunction=Microservice2Config*ProcessedBusinessData->Microservice2Config*OutgoingStreams

  // dummy
  type OutgoingStreamsReturnedToCaller=UniversalAppDataStream
  type processOutgoingStreamsAndReturnToCallerFunction=Microservice2Config*OutgoingStreams->Microservice2Config*UniversalAppDataStream

  // dummy
  type OutgoingSreamsPersisted=int
  type ProcessOutgoingStreamsToPersistenceLayerFunction=Microservice2Config*OutgoingStreamsReturnedToCaller->int

  // dummy
  type IncomingStreamsFromOS=UniversalAppDataStream
  type RunInternallyFunction=string[]*IncomingStreamsFromOS->Microservice2Config*UniversalAppDataStream