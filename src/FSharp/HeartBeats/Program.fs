namespace HeartBeats

module Domain =
    type Genre =
        | FEMALE = 220
        | MALE = 210

    type Person(genre: Genre, age: int) =
        member this.Genre = genre
        member this.Age = age

        member this.HeartBeats() : float = (float (int this.Genre - this.Age)) / 10.0


module private UserInput =
    open Domain
    open System

    exception InvalidGenre of string

    let private mapCharToGenre =
        function
        | 'F' -> Genre.FEMALE
        | 'M' -> Genre.MALE
        | _ -> raise (InvalidGenre "Genero inválido")


    let rec private askGenre () : Genre =
        printf "Ingresa tu género [F/M]: "

        try
            Console.ReadLine().ToUpper().[0] |> mapCharToGenre
        with InvalidGenre msg ->
            printfn $"%s{msg}\n"
            askGenre ()

    let private askAge () : int =
        printf "Ingresa tú edad: "
        int (Console.ReadLine())

    let readUserInfo () : Person = (askGenre (), askAge ()) |> Person

module Program =
    open UserInput
    open Domain

    let showHeartBeats (person: Person) =
        printf $"Su pulsacion es de %.2f{person.HeartBeats()}"

    [<EntryPoint>]
    let main _ =
        readUserInfo () |> showHeartBeats
        0
