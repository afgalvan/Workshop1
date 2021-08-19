namespace Bank

open System

module Domain =
    type Transaction = { Amount: float; Date: DateTime }

    type List<'T> with
        member l.Add(element: 'T) = l @ [ element ]

    type BankAccount(name: string) =
        static let mutable _seed = 1
        let mutable _transactionHistory : Transaction list = []
        member this.Id = (_seed <- _seed + 1).ToString()
        member this.Owner = name

        member private this.ComputeBalance = List.fold (fun x y -> x + y.Amount) 0.0

        member this.Balance =
            _transactionHistory |> this.ComputeBalance

        member private this.AddTransaction(amount: float) =
            let transactions = ({ Amount = amount; Date = DateTime.Now }
            |> _transactionHistory.Add)
            _transactionHistory <- transactions
            _transactionHistory |> this.ComputeBalance

        member private this.OutOfRange() =
            raise (ArgumentOutOfRangeException "Cantidad a depositar debe ser mayor a 0.")


        member this.Deposit =
            function
            | a when a <= 0.0 -> this.OutOfRange()
            | (amount: float) -> amount |> this.AddTransaction

        member private this.InvalidOperation() =
            raise (InvalidOperationException "No hay suficientes fondos para este retiro.")

        member this.Withdraw =
            function
            | a when a <= 0.0 -> this.OutOfRange()
            | a when (this.Balance - a) < 0.0 -> this.InvalidOperation()
            | (amount: float) -> -amount |> this.AddTransaction

module Program =
    open Domain

    [<EntryPoint>]
    let main _ =
        let bankAccount = BankAccount "Rosa"
        bankAccount.Deposit 400.0 |> printfn "%f"
        bankAccount.Balance |> printfn "Balance $%f"
        bankAccount.Withdraw 100.0 |> printfn "%f"
        bankAccount.Balance |> printfn "Balance $%f"
        Console.ReadKey() |> ignore
        0
