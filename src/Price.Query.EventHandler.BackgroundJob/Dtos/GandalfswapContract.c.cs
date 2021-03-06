// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: gandalfswap_contract.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using System.Collections.Generic;
using aelf = global::AElf.CSharp.Core;

namespace Gandalf.Contracts.Swap {

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
        LiquidityToken = LiquidityToken,
        Channel = Channel,
        Pair = Pair,
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
        LiquidityToken = LiquidityToken,
        Pair = Pair,
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
        BonusFee = BonusFee,
        Channel = Channel,
        Pair = Pair,
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

  #endregion
  public static partial class GandalfSwapContractContainer
  {
    static readonly string __ServiceName = "GandalfSwapContract";

    #region Marshallers
    static readonly aelf::Marshaller<global::Google.Protobuf.WellKnownTypes.Empty> __Marshaller_google_protobuf_Empty = aelf::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Google.Protobuf.WellKnownTypes.Empty.Parser.ParseFrom);
    static readonly aelf::Marshaller<global::Gandalf.Contracts.Swap.CreatePairInput> __Marshaller_CreatePairInput = aelf::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Gandalf.Contracts.Swap.CreatePairInput.Parser.ParseFrom);
    static readonly aelf::Marshaller<global::Gandalf.Contracts.Swap.CreatePairOutput> __Marshaller_CreatePairOutput = aelf::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Gandalf.Contracts.Swap.CreatePairOutput.Parser.ParseFrom);
    static readonly aelf::Marshaller<global::Gandalf.Contracts.Swap.AddLiquidityInput> __Marshaller_AddLiquidityInput = aelf::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Gandalf.Contracts.Swap.AddLiquidityInput.Parser.ParseFrom);
    static readonly aelf::Marshaller<global::Gandalf.Contracts.Swap.AddLiquidityOutput> __Marshaller_AddLiquidityOutput = aelf::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Gandalf.Contracts.Swap.AddLiquidityOutput.Parser.ParseFrom);
    static readonly aelf::Marshaller<global::Gandalf.Contracts.Swap.RemoveLiquidityInput> __Marshaller_RemoveLiquidityInput = aelf::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Gandalf.Contracts.Swap.RemoveLiquidityInput.Parser.ParseFrom);
    static readonly aelf::Marshaller<global::Gandalf.Contracts.Swap.RemoveLiquidityOutput> __Marshaller_RemoveLiquidityOutput = aelf::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Gandalf.Contracts.Swap.RemoveLiquidityOutput.Parser.ParseFrom);
    static readonly aelf::Marshaller<global::Gandalf.Contracts.Swap.SwapExactTokenForTokenInput> __Marshaller_SwapExactTokenForTokenInput = aelf::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Gandalf.Contracts.Swap.SwapExactTokenForTokenInput.Parser.ParseFrom);
    static readonly aelf::Marshaller<global::Gandalf.Contracts.Swap.SwapOutput> __Marshaller_SwapOutput = aelf::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Gandalf.Contracts.Swap.SwapOutput.Parser.ParseFrom);
    static readonly aelf::Marshaller<global::Gandalf.Contracts.Swap.SwapTokenForExactTokenInput> __Marshaller_SwapTokenForExactTokenInput = aelf::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Gandalf.Contracts.Swap.SwapTokenForExactTokenInput.Parser.ParseFrom);
    static readonly aelf::Marshaller<global::Gandalf.Contracts.Swap.TransferLiquidityTokensInput> __Marshaller_TransferLiquidityTokensInput = aelf::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Gandalf.Contracts.Swap.TransferLiquidityTokensInput.Parser.ParseFrom);
    static readonly aelf::Marshaller<global::Google.Protobuf.WellKnownTypes.Int64Value> __Marshaller_google_protobuf_Int64Value = aelf::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Google.Protobuf.WellKnownTypes.Int64Value.Parser.ParseFrom);
    static readonly aelf::Marshaller<global::Gandalf.Contracts.Swap.PairList> __Marshaller_PairList = aelf::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Gandalf.Contracts.Swap.PairList.Parser.ParseFrom);
    static readonly aelf::Marshaller<global::Gandalf.Contracts.Swap.GetReservesInput> __Marshaller_GetReservesInput = aelf::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Gandalf.Contracts.Swap.GetReservesInput.Parser.ParseFrom);
    static readonly aelf::Marshaller<global::Gandalf.Contracts.Swap.GetReservesOutput> __Marshaller_GetReservesOutput = aelf::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Gandalf.Contracts.Swap.GetReservesOutput.Parser.ParseFrom);
    static readonly aelf::Marshaller<global::Gandalf.Contracts.Swap.GetTotalSupplyOutput> __Marshaller_GetTotalSupplyOutput = aelf::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Gandalf.Contracts.Swap.GetTotalSupplyOutput.Parser.ParseFrom);
    static readonly aelf::Marshaller<global::Gandalf.Contracts.Swap.GetLiquidityTokenBalanceOutput> __Marshaller_GetLiquidityTokenBalanceOutput = aelf::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Gandalf.Contracts.Swap.GetLiquidityTokenBalanceOutput.Parser.ParseFrom);
    static readonly aelf::Marshaller<global::Gandalf.Contracts.Swap.GetAmountInInput> __Marshaller_GetAmountInInput = aelf::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Gandalf.Contracts.Swap.GetAmountInInput.Parser.ParseFrom);
    static readonly aelf::Marshaller<global::Gandalf.Contracts.Swap.GetAmountOutInput> __Marshaller_GetAmountOutInput = aelf::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Gandalf.Contracts.Swap.GetAmountOutInput.Parser.ParseFrom);
    static readonly aelf::Marshaller<global::Gandalf.Contracts.Swap.QuoteInput> __Marshaller_QuoteInput = aelf::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Gandalf.Contracts.Swap.QuoteInput.Parser.ParseFrom);
    #endregion

    #region Methods
    static readonly aelf::Method<global::Google.Protobuf.WellKnownTypes.Empty, global::Google.Protobuf.WellKnownTypes.Empty> __Method_Initialize = new aelf::Method<global::Google.Protobuf.WellKnownTypes.Empty, global::Google.Protobuf.WellKnownTypes.Empty>(
        aelf::MethodType.Action,
        __ServiceName,
        "Initialize",
        __Marshaller_google_protobuf_Empty,
        __Marshaller_google_protobuf_Empty);

    static readonly aelf::Method<global::Gandalf.Contracts.Swap.CreatePairInput, global::Gandalf.Contracts.Swap.CreatePairOutput> __Method_CreatePair = new aelf::Method<global::Gandalf.Contracts.Swap.CreatePairInput, global::Gandalf.Contracts.Swap.CreatePairOutput>(
        aelf::MethodType.Action,
        __ServiceName,
        "CreatePair",
        __Marshaller_CreatePairInput,
        __Marshaller_CreatePairOutput);

    static readonly aelf::Method<global::Gandalf.Contracts.Swap.AddLiquidityInput, global::Gandalf.Contracts.Swap.AddLiquidityOutput> __Method_AddLiquidity = new aelf::Method<global::Gandalf.Contracts.Swap.AddLiquidityInput, global::Gandalf.Contracts.Swap.AddLiquidityOutput>(
        aelf::MethodType.Action,
        __ServiceName,
        "AddLiquidity",
        __Marshaller_AddLiquidityInput,
        __Marshaller_AddLiquidityOutput);

    static readonly aelf::Method<global::Gandalf.Contracts.Swap.RemoveLiquidityInput, global::Gandalf.Contracts.Swap.RemoveLiquidityOutput> __Method_RemoveLiquidity = new aelf::Method<global::Gandalf.Contracts.Swap.RemoveLiquidityInput, global::Gandalf.Contracts.Swap.RemoveLiquidityOutput>(
        aelf::MethodType.Action,
        __ServiceName,
        "RemoveLiquidity",
        __Marshaller_RemoveLiquidityInput,
        __Marshaller_RemoveLiquidityOutput);

    static readonly aelf::Method<global::Gandalf.Contracts.Swap.SwapExactTokenForTokenInput, global::Gandalf.Contracts.Swap.SwapOutput> __Method_SwapExactTokenForToken = new aelf::Method<global::Gandalf.Contracts.Swap.SwapExactTokenForTokenInput, global::Gandalf.Contracts.Swap.SwapOutput>(
        aelf::MethodType.Action,
        __ServiceName,
        "SwapExactTokenForToken",
        __Marshaller_SwapExactTokenForTokenInput,
        __Marshaller_SwapOutput);

    static readonly aelf::Method<global::Gandalf.Contracts.Swap.SwapTokenForExactTokenInput, global::Gandalf.Contracts.Swap.SwapOutput> __Method_SwapTokenForExactToken = new aelf::Method<global::Gandalf.Contracts.Swap.SwapTokenForExactTokenInput, global::Gandalf.Contracts.Swap.SwapOutput>(
        aelf::MethodType.Action,
        __ServiceName,
        "SwapTokenForExactToken",
        __Marshaller_SwapTokenForExactTokenInput,
        __Marshaller_SwapOutput);

    static readonly aelf::Method<global::Gandalf.Contracts.Swap.TransferLiquidityTokensInput, global::Google.Protobuf.WellKnownTypes.Empty> __Method_TransferLiquidityTokens = new aelf::Method<global::Gandalf.Contracts.Swap.TransferLiquidityTokensInput, global::Google.Protobuf.WellKnownTypes.Empty>(
        aelf::MethodType.Action,
        __ServiceName,
        "TransferLiquidityTokens",
        __Marshaller_TransferLiquidityTokensInput,
        __Marshaller_google_protobuf_Empty);

    static readonly aelf::Method<global::Google.Protobuf.WellKnownTypes.Int64Value, global::Google.Protobuf.WellKnownTypes.Empty> __Method_SetFeeRate = new aelf::Method<global::Google.Protobuf.WellKnownTypes.Int64Value, global::Google.Protobuf.WellKnownTypes.Empty>(
        aelf::MethodType.Action,
        __ServiceName,
        "SetFeeRate",
        __Marshaller_google_protobuf_Int64Value,
        __Marshaller_google_protobuf_Empty);

    static readonly aelf::Method<global::Google.Protobuf.WellKnownTypes.Empty, global::Gandalf.Contracts.Swap.PairList> __Method_GetPairs = new aelf::Method<global::Google.Protobuf.WellKnownTypes.Empty, global::Gandalf.Contracts.Swap.PairList>(
        aelf::MethodType.View,
        __ServiceName,
        "GetPairs",
        __Marshaller_google_protobuf_Empty,
        __Marshaller_PairList);

    static readonly aelf::Method<global::Gandalf.Contracts.Swap.GetReservesInput, global::Gandalf.Contracts.Swap.GetReservesOutput> __Method_GetReserves = new aelf::Method<global::Gandalf.Contracts.Swap.GetReservesInput, global::Gandalf.Contracts.Swap.GetReservesOutput>(
        aelf::MethodType.View,
        __ServiceName,
        "GetReserves",
        __Marshaller_GetReservesInput,
        __Marshaller_GetReservesOutput);

    static readonly aelf::Method<global::Gandalf.Contracts.Swap.PairList, global::Gandalf.Contracts.Swap.GetTotalSupplyOutput> __Method_GetTotalSupply = new aelf::Method<global::Gandalf.Contracts.Swap.PairList, global::Gandalf.Contracts.Swap.GetTotalSupplyOutput>(
        aelf::MethodType.View,
        __ServiceName,
        "GetTotalSupply",
        __Marshaller_PairList,
        __Marshaller_GetTotalSupplyOutput);

    static readonly aelf::Method<global::Gandalf.Contracts.Swap.PairList, global::Gandalf.Contracts.Swap.GetLiquidityTokenBalanceOutput> __Method_GetLiquidityTokenBalance = new aelf::Method<global::Gandalf.Contracts.Swap.PairList, global::Gandalf.Contracts.Swap.GetLiquidityTokenBalanceOutput>(
        aelf::MethodType.View,
        __ServiceName,
        "GetLiquidityTokenBalance",
        __Marshaller_PairList,
        __Marshaller_GetLiquidityTokenBalanceOutput);

    static readonly aelf::Method<global::Google.Protobuf.WellKnownTypes.Empty, global::Gandalf.Contracts.Swap.PairList> __Method_GetAccountAssets = new aelf::Method<global::Google.Protobuf.WellKnownTypes.Empty, global::Gandalf.Contracts.Swap.PairList>(
        aelf::MethodType.View,
        __ServiceName,
        "GetAccountAssets",
        __Marshaller_google_protobuf_Empty,
        __Marshaller_PairList);

    static readonly aelf::Method<global::Gandalf.Contracts.Swap.GetAmountInInput, global::Google.Protobuf.WellKnownTypes.Int64Value> __Method_GetAmountIn = new aelf::Method<global::Gandalf.Contracts.Swap.GetAmountInInput, global::Google.Protobuf.WellKnownTypes.Int64Value>(
        aelf::MethodType.View,
        __ServiceName,
        "GetAmountIn",
        __Marshaller_GetAmountInInput,
        __Marshaller_google_protobuf_Int64Value);

    static readonly aelf::Method<global::Gandalf.Contracts.Swap.GetAmountOutInput, global::Google.Protobuf.WellKnownTypes.Int64Value> __Method_GetAmountOut = new aelf::Method<global::Gandalf.Contracts.Swap.GetAmountOutInput, global::Google.Protobuf.WellKnownTypes.Int64Value>(
        aelf::MethodType.View,
        __ServiceName,
        "GetAmountOut",
        __Marshaller_GetAmountOutInput,
        __Marshaller_google_protobuf_Int64Value);

    static readonly aelf::Method<global::Gandalf.Contracts.Swap.QuoteInput, global::Google.Protobuf.WellKnownTypes.Int64Value> __Method_Quote = new aelf::Method<global::Gandalf.Contracts.Swap.QuoteInput, global::Google.Protobuf.WellKnownTypes.Int64Value>(
        aelf::MethodType.View,
        __ServiceName,
        "Quote",
        __Marshaller_QuoteInput,
        __Marshaller_google_protobuf_Int64Value);

    #endregion

    #region Descriptors
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::Gandalf.Contracts.Swap.GandalfswapContractReflection.Descriptor.Services[0]; }
    }

    public static global::System.Collections.Generic.IReadOnlyList<global::Google.Protobuf.Reflection.ServiceDescriptor> Descriptors
    {
      get
      {
        return new global::System.Collections.Generic.List<global::Google.Protobuf.Reflection.ServiceDescriptor>()
        {
          global::Gandalf.Contracts.Swap.GandalfswapContractReflection.Descriptor.Services[0],
        };
      }
    }
    #endregion

    /// <summary>Base class for the contract of GandalfSwapContract</summary>
  }
}
#endregion

