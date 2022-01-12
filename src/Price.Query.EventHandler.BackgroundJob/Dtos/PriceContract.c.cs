// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: price_contract.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using System.Collections.Generic;
using aelf = global::AElf.CSharp.Core;

namespace AElf.Contracts.Price {

  #region Events
  public partial class NewestSwapPriceUpdated : aelf::IEvent<NewestSwapPriceUpdated>
  {
    public global::System.Collections.Generic.IEnumerable<NewestSwapPriceUpdated> GetIndexed()
    {
      return new List<NewestSwapPriceUpdated>
      {
      };
    }

    public NewestSwapPriceUpdated GetNonIndexed()
    {
      return new NewestSwapPriceUpdated
      {
        TokenSymbol = TokenSymbol,
        TargetTokenSymbol = TargetTokenSymbol,
        Price = Price,
        Timestamp = Timestamp,
        QueryId = QueryId,
      };
    }
  }

  public partial class NewestExchangePriceUpdated : aelf::IEvent<NewestExchangePriceUpdated>
  {
    public global::System.Collections.Generic.IEnumerable<NewestExchangePriceUpdated> GetIndexed()
    {
      return new List<NewestExchangePriceUpdated>
      {
      };
    }

    public NewestExchangePriceUpdated GetNonIndexed()
    {
      return new NewestExchangePriceUpdated
      {
        TokenSymbol = TokenSymbol,
        TargetTokenSymbol = TargetTokenSymbol,
        Price = Price,
        Timestamp = Timestamp,
        PriceSupplier = PriceSupplier,
        QueryId = QueryId,
      };
    }
  }

  #endregion
  public static partial class PriceContractContainer
  {
    static readonly string __ServiceName = "PriceContract";

    #region Marshallers
    static readonly aelf::Marshaller<global::AElf.Contracts.Price.InitializeInput> __Marshaller_InitializeInput = aelf::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::AElf.Contracts.Price.InitializeInput.Parser.ParseFrom);
    static readonly aelf::Marshaller<global::Google.Protobuf.WellKnownTypes.Empty> __Marshaller_google_protobuf_Empty = aelf::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Google.Protobuf.WellKnownTypes.Empty.Parser.ParseFrom);
    static readonly aelf::Marshaller<global::AElf.Contracts.Price.QueryTokenPriceInput> __Marshaller_QueryTokenPriceInput = aelf::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::AElf.Contracts.Price.QueryTokenPriceInput.Parser.ParseFrom);
    static readonly aelf::Marshaller<global::AElf.Types.Hash> __Marshaller_aelf_Hash = aelf::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::AElf.Types.Hash.Parser.ParseFrom);
    static readonly aelf::Marshaller<global::CallbackInput> __Marshaller_CallbackInput = aelf::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::CallbackInput.Parser.ParseFrom);
    static readonly aelf::Marshaller<global::AElf.Contracts.Price.UpdateSwapTokenTraceInfoInput> __Marshaller_UpdateSwapTokenTraceInfoInput = aelf::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::AElf.Contracts.Price.UpdateSwapTokenTraceInfoInput.Parser.ParseFrom);
    static readonly aelf::Marshaller<global::AElf.Contracts.Price.AuthorizedSwapTokenPriceQueryUsers> __Marshaller_AuthorizedSwapTokenPriceQueryUsers = aelf::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::AElf.Contracts.Price.AuthorizedSwapTokenPriceQueryUsers.Parser.ParseFrom);
    static readonly aelf::Marshaller<global::AElf.Contracts.Price.ChangeOracleInput> __Marshaller_ChangeOracleInput = aelf::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::AElf.Contracts.Price.ChangeOracleInput.Parser.ParseFrom);
    static readonly aelf::Marshaller<global::AElf.Contracts.Price.ChangeTracePathLimitInput> __Marshaller_ChangeTracePathLimitInput = aelf::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::AElf.Contracts.Price.ChangeTracePathLimitInput.Parser.ParseFrom);
    static readonly aelf::Marshaller<global::AElf.Contracts.Price.GetSwapTokenPriceInfoInput> __Marshaller_GetSwapTokenPriceInfoInput = aelf::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::AElf.Contracts.Price.GetSwapTokenPriceInfoInput.Parser.ParseFrom);
    static readonly aelf::Marshaller<global::AElf.Contracts.Price.Price> __Marshaller_Price = aelf::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::AElf.Contracts.Price.Price.Parser.ParseFrom);
    static readonly aelf::Marshaller<global::AElf.Contracts.Price.GetBatchSwapTokenPriceInfoInput> __Marshaller_GetBatchSwapTokenPriceInfoInput = aelf::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::AElf.Contracts.Price.GetBatchSwapTokenPriceInfoInput.Parser.ParseFrom);
    static readonly aelf::Marshaller<global::AElf.Contracts.Price.BatchPrices> __Marshaller_BatchPrices = aelf::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::AElf.Contracts.Price.BatchPrices.Parser.ParseFrom);
    static readonly aelf::Marshaller<global::AElf.Contracts.Price.GetExchangeTokenPriceInfoInput> __Marshaller_GetExchangeTokenPriceInfoInput = aelf::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::AElf.Contracts.Price.GetExchangeTokenPriceInfoInput.Parser.ParseFrom);
    static readonly aelf::Marshaller<global::AElf.Contracts.Price.GetBatchExchangeTokenPriceInfoInput> __Marshaller_GetBatchExchangeTokenPriceInfoInput = aelf::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::AElf.Contracts.Price.GetBatchExchangeTokenPriceInfoInput.Parser.ParseFrom);
    static readonly aelf::Marshaller<global::AElf.Contracts.Price.IsQueryIdExisted> __Marshaller_IsQueryIdExisted = aelf::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::AElf.Contracts.Price.IsQueryIdExisted.Parser.ParseFrom);
    static readonly aelf::Marshaller<global::AElf.Contracts.Price.TracePathLimit> __Marshaller_TracePathLimit = aelf::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::AElf.Contracts.Price.TracePathLimit.Parser.ParseFrom);
    #endregion

    #region Methods
    static readonly aelf::Method<global::AElf.Contracts.Price.InitializeInput, global::Google.Protobuf.WellKnownTypes.Empty> __Method_Initialize = new aelf::Method<global::AElf.Contracts.Price.InitializeInput, global::Google.Protobuf.WellKnownTypes.Empty>(
        aelf::MethodType.Action,
        __ServiceName,
        "Initialize",
        __Marshaller_InitializeInput,
        __Marshaller_google_protobuf_Empty);

    static readonly aelf::Method<global::AElf.Contracts.Price.QueryTokenPriceInput, global::AElf.Types.Hash> __Method_QuerySwapTokenPrice = new aelf::Method<global::AElf.Contracts.Price.QueryTokenPriceInput, global::AElf.Types.Hash>(
        aelf::MethodType.Action,
        __ServiceName,
        "QuerySwapTokenPrice",
        __Marshaller_QueryTokenPriceInput,
        __Marshaller_aelf_Hash);

    static readonly aelf::Method<global::AElf.Contracts.Price.QueryTokenPriceInput, global::AElf.Types.Hash> __Method_QueryExchangeTokenPrice = new aelf::Method<global::AElf.Contracts.Price.QueryTokenPriceInput, global::AElf.Types.Hash>(
        aelf::MethodType.Action,
        __ServiceName,
        "QueryExchangeTokenPrice",
        __Marshaller_QueryTokenPriceInput,
        __Marshaller_aelf_Hash);

    static readonly aelf::Method<global::CallbackInput, global::Google.Protobuf.WellKnownTypes.Empty> __Method_RecordSwapTokenPrice = new aelf::Method<global::CallbackInput, global::Google.Protobuf.WellKnownTypes.Empty>(
        aelf::MethodType.Action,
        __ServiceName,
        "RecordSwapTokenPrice",
        __Marshaller_CallbackInput,
        __Marshaller_google_protobuf_Empty);

    static readonly aelf::Method<global::CallbackInput, global::Google.Protobuf.WellKnownTypes.Empty> __Method_RecordExchangeTokenPrice = new aelf::Method<global::CallbackInput, global::Google.Protobuf.WellKnownTypes.Empty>(
        aelf::MethodType.Action,
        __ServiceName,
        "RecordExchangeTokenPrice",
        __Marshaller_CallbackInput,
        __Marshaller_google_protobuf_Empty);

    static readonly aelf::Method<global::AElf.Contracts.Price.UpdateSwapTokenTraceInfoInput, global::Google.Protobuf.WellKnownTypes.Empty> __Method_UpdateSwapTokenTraceInfo = new aelf::Method<global::AElf.Contracts.Price.UpdateSwapTokenTraceInfoInput, global::Google.Protobuf.WellKnownTypes.Empty>(
        aelf::MethodType.Action,
        __ServiceName,
        "UpdateSwapTokenTraceInfo",
        __Marshaller_UpdateSwapTokenTraceInfoInput,
        __Marshaller_google_protobuf_Empty);

    static readonly aelf::Method<global::AElf.Contracts.Price.AuthorizedSwapTokenPriceQueryUsers, global::Google.Protobuf.WellKnownTypes.Empty> __Method_UpdateAuthorizedSwapTokenPriceQueryUsers = new aelf::Method<global::AElf.Contracts.Price.AuthorizedSwapTokenPriceQueryUsers, global::Google.Protobuf.WellKnownTypes.Empty>(
        aelf::MethodType.Action,
        __ServiceName,
        "UpdateAuthorizedSwapTokenPriceQueryUsers",
        __Marshaller_AuthorizedSwapTokenPriceQueryUsers,
        __Marshaller_google_protobuf_Empty);

    static readonly aelf::Method<global::AElf.Contracts.Price.ChangeOracleInput, global::Google.Protobuf.WellKnownTypes.Empty> __Method_ChangeOracle = new aelf::Method<global::AElf.Contracts.Price.ChangeOracleInput, global::Google.Protobuf.WellKnownTypes.Empty>(
        aelf::MethodType.Action,
        __ServiceName,
        "ChangeOracle",
        __Marshaller_ChangeOracleInput,
        __Marshaller_google_protobuf_Empty);

    static readonly aelf::Method<global::AElf.Contracts.Price.ChangeTracePathLimitInput, global::Google.Protobuf.WellKnownTypes.Empty> __Method_ChangeTracePathLimit = new aelf::Method<global::AElf.Contracts.Price.ChangeTracePathLimitInput, global::Google.Protobuf.WellKnownTypes.Empty>(
        aelf::MethodType.Action,
        __ServiceName,
        "ChangeTracePathLimit",
        __Marshaller_ChangeTracePathLimitInput,
        __Marshaller_google_protobuf_Empty);

    static readonly aelf::Method<global::AElf.Contracts.Price.GetSwapTokenPriceInfoInput, global::AElf.Contracts.Price.Price> __Method_GetSwapTokenPriceInfo = new aelf::Method<global::AElf.Contracts.Price.GetSwapTokenPriceInfoInput, global::AElf.Contracts.Price.Price>(
        aelf::MethodType.View,
        __ServiceName,
        "GetSwapTokenPriceInfo",
        __Marshaller_GetSwapTokenPriceInfoInput,
        __Marshaller_Price);

    static readonly aelf::Method<global::AElf.Contracts.Price.GetBatchSwapTokenPriceInfoInput, global::AElf.Contracts.Price.BatchPrices> __Method_GetBatchSwapTokenPriceInfo = new aelf::Method<global::AElf.Contracts.Price.GetBatchSwapTokenPriceInfoInput, global::AElf.Contracts.Price.BatchPrices>(
        aelf::MethodType.View,
        __ServiceName,
        "GetBatchSwapTokenPriceInfo",
        __Marshaller_GetBatchSwapTokenPriceInfoInput,
        __Marshaller_BatchPrices);

    static readonly aelf::Method<global::AElf.Contracts.Price.GetExchangeTokenPriceInfoInput, global::AElf.Contracts.Price.Price> __Method_GetExchangeTokenPriceInfo = new aelf::Method<global::AElf.Contracts.Price.GetExchangeTokenPriceInfoInput, global::AElf.Contracts.Price.Price>(
        aelf::MethodType.View,
        __ServiceName,
        "GetExchangeTokenPriceInfo",
        __Marshaller_GetExchangeTokenPriceInfoInput,
        __Marshaller_Price);

    static readonly aelf::Method<global::AElf.Contracts.Price.GetBatchExchangeTokenPriceInfoInput, global::AElf.Contracts.Price.BatchPrices> __Method_GetBatchExchangeTokenPriceInfo = new aelf::Method<global::AElf.Contracts.Price.GetBatchExchangeTokenPriceInfoInput, global::AElf.Contracts.Price.BatchPrices>(
        aelf::MethodType.View,
        __ServiceName,
        "GetBatchExchangeTokenPriceInfo",
        __Marshaller_GetBatchExchangeTokenPriceInfoInput,
        __Marshaller_BatchPrices);

    static readonly aelf::Method<global::AElf.Types.Hash, global::AElf.Contracts.Price.IsQueryIdExisted> __Method_CheckQueryIdIfExisted = new aelf::Method<global::AElf.Types.Hash, global::AElf.Contracts.Price.IsQueryIdExisted>(
        aelf::MethodType.View,
        __ServiceName,
        "CheckQueryIdIfExisted",
        __Marshaller_aelf_Hash,
        __Marshaller_IsQueryIdExisted);

    static readonly aelf::Method<global::Google.Protobuf.WellKnownTypes.Empty, global::AElf.Contracts.Price.AuthorizedSwapTokenPriceQueryUsers> __Method_GetAuthorizedSwapTokenPriceQueryUsers = new aelf::Method<global::Google.Protobuf.WellKnownTypes.Empty, global::AElf.Contracts.Price.AuthorizedSwapTokenPriceQueryUsers>(
        aelf::MethodType.View,
        __ServiceName,
        "GetAuthorizedSwapTokenPriceQueryUsers",
        __Marshaller_google_protobuf_Empty,
        __Marshaller_AuthorizedSwapTokenPriceQueryUsers);

    static readonly aelf::Method<global::Google.Protobuf.WellKnownTypes.Empty, global::AElf.Contracts.Price.TracePathLimit> __Method_GetTracePathLimit = new aelf::Method<global::Google.Protobuf.WellKnownTypes.Empty, global::AElf.Contracts.Price.TracePathLimit>(
        aelf::MethodType.View,
        __ServiceName,
        "GetTracePathLimit",
        __Marshaller_google_protobuf_Empty,
        __Marshaller_TracePathLimit);

    #endregion

    #region Descriptors
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::AElf.Contracts.Price.PriceContractReflection.Descriptor.Services[0]; }
    }

    public static global::System.Collections.Generic.IReadOnlyList<global::Google.Protobuf.Reflection.ServiceDescriptor> Descriptors
    {
      get
      {
        return new global::System.Collections.Generic.List<global::Google.Protobuf.Reflection.ServiceDescriptor>()
        {
          global::AElf.Contracts.Price.PriceContractReflection.Descriptor.Services[0],
        };
      }
    }
    #endregion
  }
}
#endregion
