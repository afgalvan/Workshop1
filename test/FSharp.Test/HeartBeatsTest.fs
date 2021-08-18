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
open HeartBeats.Domain

[<Test>]
let shouldCalculateCorrectHeartBeatsWhenIsMale() =
     let person = Person(Genre.MALE, 43)
     person.HeartBeats() |> should equal 16.7

[<Test>]
let shouldCalculateCorrectHeartBeatsWhenIsFemale() =
     let person = Person(Genre.FEMALE, 43)
     person.HeartBeats() |> should equal 17.7
