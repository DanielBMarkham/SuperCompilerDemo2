namespace Microservice3
open Application1.AppTypes
module Types=
  type Microservice3Config=UniversalMicroserviceConfig
  type GetConfigurationFunction=string[]->Microservice3Config

  type GetIncomingStreamFunction=Microservice3Config->Microservice3Config*UniversalAppDataStream

  // Dummy Type
  type IncomingData=string
  type ProcessIncomingDataFunction=Microservice3Config*UniversalAppDataStream->Microservice3Config*IncomingData

  // Dummy type
  type BusinessTypes=string
  type TranslateIncomingDataToBusinessTypesFunction=Microservice3Config*IncomingData->Microservice3Config*BusinessTypes

  type ValidatedBusinessDataType=string
  type ValidateBusinessDataWithItselfFunction=Microservice3Config*BusinessTypes->Microservice3Config*ValidatedBusinessDataType

// more dummy types
  type  ProcessedBusinessData=string
  type ProcessDataFunction=Microservice3Config*ValidatedBusinessDataType->Microservice3Config*ProcessedBusinessData

  //dummy
  type OutgoingStreams=string
  type CreateOutgoingStreamsFromProcessedDataFunction=Microservice3Config*ProcessedBusinessData->Microservice3Config*OutgoingStreams

  // dummy
  type OutgoingStreamsReturnedToCaller=UniversalAppDataStream
  type processOutgoingStreamsAndReturnToCallerFunction=Microservice3Config*OutgoingStreams->Microservice3Config*UniversalAppDataStream

  // dummy
  type OutgoingSreamsPersisted=int
  type ProcessOutgoingStreamsToPersistenceLayerFunction=Microservice3Config*OutgoingStreamsReturnedToCaller->int

  // dummy
  type IncomingStreamsFromOS=UniversalAppDataStream
  type RunInternallyFunction=string[]*IncomingStreamsFromOS->Microservice3Config*UniversalAppDataStream