// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: awaken_swap_contract.proto
// </auto-generated>
#pragma warning disable 0414, 1591

using System.Collections.Generic;
using aelf = global::AElf.CSharp.Core;

namespace Awaken.Contracts.Swap {

  #region Events
  public partial class PairCreated : aelf::IEvent<PairCreated>
  {
    public global::System.Collections.Generic.IEnumerable<PairCreated> GetIndexed()
    {
      return new List<PairCreated>
      {
      };
    }

    public PairCreated GetNonIndexed()
    {
      return new PairCreated
      {
        SymbolA = SymbolA,
        SymbolB = SymbolB,
        Pair = Pair,
      };
    }
  }

  public partial class LiquidityAdded : aelf::IEvent<LiquidityAdded>
  {
    public global::System.Collections.Generic.IEnumerable<LiquidityAdded> GetIndexed()
    {
      return new List<LiquidityAdded>
      {
      };
    }

    public LiquidityAdded GetNonIndexed()
    {
      return new LiquidityAdded
      {
        Sender = Sender,
        SymbolA = SymbolA,
        SymbolB = SymbolB,
        AmountA = AmountA,
        AmountB = AmountB,
        To = To,
        Pair = Pair,
        LiquidityToken = LiquidityToken,
        Channel = Channel,
      };
    }
  }

  public partial class LiquidityRemoved : aelf::IEvent<LiquidityRemoved>
  {
    public global::System.Collections.Generic.IEnumerable<LiquidityRemoved> GetIndexed()
    {
      return new List<LiquidityRemoved>
      {
      };
    }

    public LiquidityRemoved GetNonIndexed()
    {
      return new LiquidityRemoved
      {
        Sender = Sender,
        SymbolA = SymbolA,
        SymbolB = SymbolB,
        AmountA = AmountA,
        AmountB = AmountB,
        To = To,
        Pair = Pair,
        LiquidityToken = LiquidityToken,
      };
    }
  }

  public partial class Swap : aelf::IEvent<Swap>
  {
    public global::System.Collections.Generic.IEnumerable<Swap> GetIndexed()
    {
      return new List<Swap>
      {
      };
    }

    public Swap GetNonIndexed()
    {
      return new Swap
      {
        Sender = Sender,
        SymbolIn = SymbolIn,
        SymbolOut = SymbolOut,
        AmountIn = AmountIn,
        AmountOut = AmountOut,
        TotalFee = TotalFee,
        Pair = Pair,
        To = To,
        Channel = Channel,
      };
    }
  }

  public partial class Sync : aelf::IEvent<Sync>
  {
    public global::System.Collections.Generic.IEnumerable<Sync> GetIndexed()
    {
      return new List<Sync>
      {
      };
    }

    public Sync GetNonIndexed()
    {
      return new Sync
      {
        SymbolA = SymbolA,
        SymbolB = SymbolB,
        ReserveA = ReserveA,
        ReserveB = ReserveB,
        Pair = Pair,
      };
    }
  }
}
#endregion

