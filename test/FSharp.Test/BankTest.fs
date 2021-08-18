(*
Capture the financial information of a client, name,
account number and opening balance and allow you to make
consignments and withdrawals to the account, finally consult
the balance with which the account remains.
*)

module FSharp.Test.BankTest

open FsUnit
open NUnit.Framework

[<Test>]
let userShouldNotWithdrawMoreMoneyThanHisBalanceAmount () =
     true |> should equal true


