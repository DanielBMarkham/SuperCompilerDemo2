namespace Microservice1
open Application1.AppTypes
module Types=
  type Microservice1Config=UniversalMicroserviceConfig
  type GetConfigurationFunction=string[]->Microservice1Config

  type GetIncomingStreamFunction=Microservice1Config->Microservice1Config*UniversalAppDataStream

  // Dummy Type
  type IncomingData=string
  type ProcessIncomingDataFunction=Microservice1Config*UniversalAppDataStream->Microservice1Config*IncomingData

  // Dummy type
  type BusinessTypes=string
  type TranslateIncomingDataToBusinessTypesFunction=Microservice1Config*IncomingData->Microservice1Config*BusinessTypes

  type ValidatedBusinessDataType=string
  type ValidateBusinessDataWithItselfFunction=Microservice1Config*BusinessTypes->Microservice1Config*ValidatedBusinessDataType

// more dummy types
  type  ProcessedBusinessData=string
  type ProcessDataFunction=Microservice1Config*ValidatedBusinessDataType->Microservice1Config*ProcessedBusinessData

  //dummy
  type OutgoingStreams=string
  type CreateOutgoingStreamsFromProcessedDataFunction=Microservice1Config*ProcessedBusinessData->Microservice1Config*OutgoingStreams

  // dummy
  type OutgoingStreamsReturnedToCaller=UniversalAppDataStream
  type processOutgoingStreamsAndReturnToCallerFunction=Microservice1Config*OutgoingStreams->Microservice1Config*UniversalAppDataStream

  // dummy
  type OutgoingSreamsPersisted=int
  type ProcessOutgoingStreamsToPersistenceLayerFunction=Microservice1Config*OutgoingStreamsReturnedToCaller->int

  // dummy
  type IncomingStreamsFromOS=UniversalAppDataStream
  type RunInternallyFunction=string[]*IncomingStreamsFromOS->Microservice1Config*UniversalAppDataStream
