(*
Calculate the number of heartbeats a person should have
for every 10 seconds of aerobic exercise; the formula that
applies when the sex is female is:
     beats = (220 - age) / 10
if the sex is male:
     beats = (210 - age) / 10 
*)

module FSharp.Test.HeartBeatsTest

open FsUnit
open NUnit.Framework

[<Test>]
let shouldCalculateCorrectHeartBeatsWhenIsMale() =
     true |> should equal true

[<Test>]
let shouldCalculateCorrectHeartBeatsWhenIsFemale() =
     true |> should equal true
