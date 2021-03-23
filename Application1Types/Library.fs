namespace Application1
module AppTypes=

  type UniversalAppDataStream = {
    StreamName:string
    DataLines:seq<string>
    }
  type UniversalConfigItems=seq<string>
  type UniversalAppConfig=UniversalConfigItems
  type App1Config=UniversalConfigItems


  type App1Microservice1Config  = {App1Config:UniversalAppConfig;Microservice1ConfigItems:UniversalConfigItems}
  type App1Microservice2Config  = {App1Config:UniversalAppConfig;Microservice2ConfigItems:UniversalConfigItems}
  type App1Microservice3Config  = {App1Config:UniversalAppConfig;Microservice3ConfigItems:UniversalConfigItems}

  type App1Microservice1=App1Microservice1Config*UniversalAppDataStream->UniversalAppDataStream
  type App1Microservice2=App1Microservice2Config*UniversalAppDataStream->UniversalAppDataStream
  type App1Microservice3=App1Microservice3Config*UniversalAppDataStream->UniversalAppDataStream

  type UniversalMicroserviceConfig=UniversalConfigItems
  type GetAPPConfigFunction=UniversalMicroserviceConfig

