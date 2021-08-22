(*
Capture 3 grades, take the Average and determine if the student won or
lost the course (Greater than or equal to 3 won, otherwise lost)
*)

module FSharp.Test.GradesTest

open NUnit.Framework
open FsUnit
open Grades.Domain

[<Test>]
let shouldComputeCorrectAverage () =
    (Grade [ 3.0; 3.0; 3.0 ]).Prom()
    |> should equal 3.0

    (Grade [ 3.0 .. 5.0 ]).Prom() |> should equal 4.0

[<Test>]
let gradeShouldPassIfGreaterThanOrEqualToThree () =
    (Grade [ 3.0; 3.0; 3.0 ]).Passes()
    |> should equal true

    (Grade [ 5.0; 2.0; 3.5 ]).Passes()
    |> should equal true

[<Test>]
let gradeShouldNotPassIfLowerThanThree () =
    (Grade [ 2.0; 3.0; 3.0 ]).Passes()
    |> should equal false

    (Grade [ 1.0; 0.0; 2.0 ]).Passes()
    |> should equal false
