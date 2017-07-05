module wip
open Fez.Core

[<ModCall("erlang", "put")>]
let put<'a, 'b> (k: 'a) (v: 'b) : 'b option = None

let get_v =
    async {
        return "value" }

let async_start_child () =
    async {
        let! p = Async.StartChild (async {
                                        do! Async.Sleep 50
                                        return self()})
        return! p }
    |> Async.RunSynchronously

let async_run () =
    async {
        let! v = get_v
        return v}
    |> Async.RunSynchronously

(* let rarray() = *)
(*     let l = new ResizeArray<_>() *)
(*     l.Add 1 *)
(*     l *)

(* let query1 = *)
(*     query { *)
(*         for n in seq {0..10} do *)
(*             where (n > 5) *)
(*             select (n - 1) *)
(*     } *)

(* let bigints () = *)
(*     bigint 1 *)


#if FEZ
#else
let so_lazy() =
    let l = lazy 5
    //false, 5, true, 5, 5, undefined
    l.IsValueCreated, l.Force(), l.IsValueCreated,
        l.Value, l.release(), l.release()
#endif

(* let mutate() = *)
(*     let mutable v = 4 *)
(*     v <- 5 *)
(*     v *)

(* [<ModCall("erlang", "put")>] *)
(* let put<'a, 'b> (k: 'a) (v: 'b) : 'b option = None *)

(* [<ModCall("erlang", "get")>] *)
(* let get<'a, 'b> (k: 'a) : 'b option = None *)

(* let forloop() = *)
(*     let key = "fast_integer_loop_key" *)
(*     for i in 0..10 do *)
(*         printfn "put %A" i *)
(*         put key i |> ignore *)
(*     get key *)




(* let send_receive() = *)
(*     (self()) <! (1, "hi") *)
(*     match receive<int * string>() with *)
(*     | 1, s -> s *)
(*     | n, _ -> string n *)


(* let results () = *)
(*     let r = Ok 1 *)
(*     let er = Error "blah" *)
(*     let r = Result.bind (fun x -> Ok (x + 1)) r *)
(*     let r = Result.map ((+) 2) r *)
(*     let er = Result.mapError String.length er *)
(*     r, er, r *)

(* [<AbstractClass>] *)
(* type SomeT() = *)
(*     abstract Prt: unit -> string *)

(* type T2() = *)
(*     inherit SomeT() *)
(*     override x.Prt() = "" *)

(* type T3() = *)
(*     inherit T2() *)

(* let t = *)
(*     let t = T3() *)
(*     t.Prt() *)

(*
 *
[<ErlangTerm>]
type TimeUnit =
    | Second
    | Millisecond
    | Microsecond
    | Nanosecond
    | Native
    | Perf_counter
    | Integer of int //erased to value
    | SomeTuple of int * string //erased to tuple

[<ModCall("os", "system_time")>]
let os_system_time (opt : TimeUnit) =
    0L //dummy

let now () =
    os_system_time(Second),
    os_system_time(Integer 4)

let erlangTermRoundtrip () =


let estuff =
    function
    | Second -> "second"
    | Integer i -> sprintf "%i" i
    | SomeTuple (i, s) -> sprintf "%i %s" i s
    | _ -> "def"


*)

(* [<ModCall("erlang", "round")>] *)
(* let erlang_round (n: float) = *)
(*     0L *)

(* let t = *)
(*     "hey"B *)


(* type MyType = int * string *)

(*
type IPrt =
    abstract member Prt: unit ->  string

type Obj =
    | O
    interface System.IDisposable with
        member x.Dispose() =  printfn "dispose"
    interface IPrt with
        member x.Prt() = sprintf "%A" x

let bah () =
    use o = O
    (o :> IPrt).Prt()

*)
    (*
exception SomeEx of string * int

let ex() =
    let x = SomeEx("banan", 12) :?> SomeEx
    x.Message
    *)
