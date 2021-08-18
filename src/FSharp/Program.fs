namespace FSharp

module Grades =
    type Grade(grades: float list) =
        member this.Grades = grades

        member this.ComputeProm() : float =
            // this.Grades |> List.average
            let div (a: float) (b: float) = b / a

            this.Grades
            |> List.reduce (fun x y -> x + y)
            |> div (float this.Grades.Length)

        member this.Passes() : bool = this.ComputeProm() >= 3.0


module private UserInput =
    open System

    let private askGrade (gradeIndex: int) : float =
        printf $"{gradeIndex}. Ingrese una nota: "
        float (Console.ReadLine())

    let inline askUserGrades (amount: int) : float list = [ for i in 1 .. amount do askGrade i ]

module private ConsoleOutput =
    open Grades

    let resultString (grade: Grade) : string = if grade.Passes() then "ganó" else "perdió"

    let showResults (grade: Grade) : unit =
        printf $"\nEl estudiante {resultString grade} la materia con una nota de %.2f{grade.ComputeProm()}."

module Program =
    open Grades
    open UserInput
    open ConsoleOutput

    let gradesAmount = 3

    [<EntryPoint>]
    let main _ =
        askUserGrades gradesAmount
        |> Grade
        |> showResults
        0
