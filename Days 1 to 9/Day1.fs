[<AutoOpen>]
module Day1

open System
open System.IO

let getText projectDir =
    let fileStream = new StreamReader(projectDir + "\\Day1Input.txt")
    fileStream.ReadToEnd().Split([|"\r\n"|], StringSplitOptions.None)
    |> Array.map (fun a -> Int32.Parse(a))

//Key observation: if we are comparing sums of n consecutive elements, 
//                 then s_i+1 > s_i iff a[i+n] > a[i]
let part12 n (sourceArray: int[]) =
    Seq.init (sourceArray.Length - n) (fun i -> if sourceArray.[i+n] > sourceArray.[i] 
                                                then 1 else 0)
    |> Seq.sum

//Entry point
let main projectDir =
    let sourceData = getText projectDir
    Console.WriteLine("Part 1: " + (part12 1 sourceData).ToString() )
    Console.WriteLine("Part 2: " + (part12 3 sourceData).ToString() )
    1