(*
Capture the financial information of a client, name,
account number and opening balance and allow you to make
consignments and withdrawals to the account, finally consult
the balance with which the account remains.
*)

module FSharp.Test.BankTest

open System
open Bank.Domain
open FsUnit
open NUnit.Framework


[<Test>]
let accountShouldNotDepositNegativeAmounts () =
    let account = BankAccount "Test"

    (fun () -> account.Deposit -200.0 |> ignore)
    |> should throw typeof<ArgumentOutOfRangeException>

    account.Balance |> should equal 0.0

[<Test>]
let accountBalanceShouldReflectWhenADepositIsMade () =
    let account = BankAccount "Test"
    account.Deposit 200.0 |> ignore

    account.Balance |> should equal 200.0

[<Test>]
let accountShouldNotWithdrawMoreMoneyThanHisBalanceAmount () =
    let account = BankAccount "Test"

    (fun () -> account.Withdraw 300.0 |> ignore)
    |> should throw typeof<InvalidOperationException>

    account.Balance |> should equal 0.0

[<Test>]
let accountBalanceShouldBeDiscountedAfterAWithdraw () =
    let account = BankAccount "Test"
    account.Deposit 200.0 |> ignore
    account.Withdraw 100.0 |> ignore

    account.Balance |> should equal 100.0
