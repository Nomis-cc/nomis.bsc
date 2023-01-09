export const blockchains = [
  {
    group: "finance",
    groupLabel: "Finance",
    item: "Binance",
    slug: "bsc",
    apiSlug: "bsc",
    icon: "/blockchains/binance.svg",
    placeholder: "0x... address",
    coin: "BNB",
    contractAddress: "0x787aE42E3a8C6E10d6B38245f35f61eEf42A8eA8",
    chainId: 56,
    networkData: {
      chainId: "0x38",
      chainName: "Binance Smart Chain Mainnet",
      nativeCurrency: {
        name: "BNB",
        symbol: "BNB",
        decimals: 18,
      },
      rpcUrls: ["https://bsc-dataseed1.binance.org"],
      blockExplorerUrls: ["https://bscscan.com"],
    },
  },
];
