open Expecto
open Expecto.Logging
open Expecto.Logging.Message

// DON'T DO THIS. IT INTRODUCES CYCLES
//YOUR APP-TYPE FILES ARE MEANT FOR ENTERPRISE CALLERS
//open Application1Types

open Microservice1.Types
open Microservice1.Main
open Microservice2.Types
open Microservice2.Main
open Microservice3.Types
open Microservice3.Main

module ApplicationTests=

  let applicationTestInputData1 = emptyAppDataTransfer
  let microservice1ProcessingApplicationTestData1 = emptyAppDataTransfer
  let microservice2ProcessingMicroservice1FromTestAppInputData = emptyAppDataTransfer

  let flowTests =
    testList "Microservices Flow Test. SHOULD BE AUTOGEN BASED ON USER DIAGRAM?" [
      test "Microservice1 runs with no input" {
        let commandArgs=[||]
        let res=Microservice1.Main.runInternally(commandArgs,emptyAppDataTransfer)
        Expect.equal res (defaultApp1Microservice1Config, emptyAppDataTransfer) "No data in means no data out"
      }
    ]

[<EntryPoint>]
let main args =
  runTestsInAssemblyWithCLIArgs [] args