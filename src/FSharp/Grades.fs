namespace FSharp

module Grades =
    type Grade(grades: float list) =
        member this.Grades = grades

        member private this.ComputeProm (addMethod: float -> float -> float) (divMethod: float -> float) : float =
            this.Grades
            |> List.reduce addMethod
            |> divMethod

        member this.Prom() : float =
            // this.Grades |> List.average
            ((fun x y -> x + y), (fun x -> x / float(this.Grades.Length)))
            ||> this.ComputeProm 


        member this.Passes() : bool = this.Prom() >= 3.0


module private UserInput =
    open System

    let private askGrade (gradeIndex: int) : float =
        printf $"{gradeIndex}. Ingrese una nota: "
        float (Console.ReadLine())

    let inline askUserGrades (amount: int) : float list =
        [ for i in 1 .. amount do
              askGrade i ]

module private ConsoleOutput =
    open Grades

    let resultString (grade: Grade) : string =
        if grade.Passes() then
            "ganó"
        else
            "perdió"

    let showResults (grade: Grade) : unit =
        printf $"\nEl estudiante {resultString grade} la materia con una nota de %.2f{grade.Prom()}."

module Program =
    open Grades
    open UserInput
    open ConsoleOutput

    let gradesAmount = 3

    [<EntryPoint>]
    let main _ =
        askUserGrades gradesAmount |> Grade |> showResults
        0
