// See https://aka.ms/new-console-template for more information

using SMFile.Application.Common.SMFile;
using SMFile.Domain.MT;

var message = "{1:F01BANKBEBBAXXX0000000000}{2:I541BANKDEFFXXXXN}{4:\n:16R:GENL\n:20C::SEME//123456789\n:23G:NEWM\n:98A::PREP//20250927\n:22F::CAEV//REDM\n:16S:GENL\n:16R:TRADDET\n:94B::TRAD//EXCH/XEUR\n:98A::TRAD//20250925\n:35B:/US/000A1EWWW0\n:16S:TRADDET\n:16R:FIAC\n:36B::SETT//UNIT/1000,\n:97A::SAFE//12345\n:16S:FIAC\n:16R:SETDET\n:22F::SETR//TRAD\n:16S:SETDET\n-}{5:{CHK:123456789ABC}}";


var swiftMsg = SwiftParser.Parse(message);
var mt = new MT541(swiftMsg);


Console.WriteLine("Parsed tags count: " + swiftMsg.Tags.Count);


// Smoke tests
//if (mt.SenderReference == null) throw new Exception("SenderReference not parsed");
//if (mt.FunctionOfMessage != "NEWM") throw new Exception("23G mismatch");
//if (mt.PreparationDate == null || mt.PreparationDate.Value != new DateTime(2025, 9, 27)) throw new Exception("Prep date mismatch");
//if (mt.TradeDate == null || mt.TradeDate.Value != new DateTime(2025, 9, 25)) throw new Exception("Trade date mismatch");
//if (mt.ISIN == null || !mt.ISIN.Contains("DE000A1EWWW0")) throw new Exception("ISIN mismatch");
//if (mt.Units == null || mt.Units != 1000) throw new Exception($"Units mismatch: {mt.Units}");
//if (mt.SafekeepingAccount == null || !mt.SafekeepingAccount.Contains("12345")) throw new Exception("Safekeeping account mismatch");


Console.WriteLine("All smoke tests passed. MT541 mapped values:");
Console.WriteLine($" SenderRef: {mt.SenderReference}");
Console.WriteLine($" Function: {mt.FunctionOfMessage}");
Console.WriteLine($" PrepDate: {mt.PreparationDate:yyyy-MM-dd}");
Console.WriteLine($" TradeDate: {mt.TradeDate:yyyy-MM-dd}");
Console.WriteLine($" ISIN: {mt.ISIN}");
Console.WriteLine($" {mt.CUSIPSCHEME}:  {mt.CUSIP}");
Console.WriteLine($" Units: {mt.Units}");
Console.WriteLine($" SafekeepingAcct: {mt.SafekeepingAccount}");
Console.WriteLine($" SafekeepingAcct: {mt.ISIN}");


// Keep console open for local runs
Console.WriteLine("Done.");
Console.WriteLine("Hello, World!");
