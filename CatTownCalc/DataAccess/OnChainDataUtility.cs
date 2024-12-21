using CatTownCalc.Model;

namespace CatTownCalc.DataAccess;
using System;
using System.Numerics;
using System.Threading.Tasks;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;


public class OnChainDataUtility
{
    public static async Task<int> GetNumberOfCatsAsync(string addr)
    {
        string rpcUrl = "https://api.developer.coinbase.com/rpc/v1/base/CthFLRfCqMHXaNqlBwQ85S7SVjbUGBy5";
        var web3 = new Web3(rpcUrl);
        int catsNo = 0;

        // Check connection
        bool isConnected = await web3.Eth.Blocks.GetBlockNumber.SendRequestAsync() != null;
        if (!isConnected)
        {
            Console.WriteLine("Failed to connect to Ethereum node.");
            return 0;
        }

        // Cat town game contract
        string contractAddress = "0x10A77395a07917C5Eb71fEEB86696B7612f9730F";
        string abi = @"[
            {
                ""constant"": true,
                ""inputs"": [{""name"": ""addr"", ""type"": ""address""}],
                ""name"": ""cats"",
                ""outputs"": [{""name"": """", ""type"": ""uint256""}],
                ""payable"": false,
                ""stateMutability"": ""view"",
                ""type"": ""function""
            }
        ]";

        // Address to test
        //string testAddress = "0x8519081783C375Da414F8187c286fFF0d60b09F7";

        try
        {
            // Load the contract
            var contract = web3.Eth.GetContract(abi, contractAddress);

            // Get the `cats` function
            var catsFunction = contract.GetFunction("cats");

            // Call the function
            catsNo = await catsFunction.CallAsync<int>(addr);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error calling function: {ex.Message}");
        }
        
        return catsNo;
    }
    
    public static async Task<int> GetNumberOfFloofsAsync(string addr)
    {
        string rpcUrl = "https://api.developer.coinbase.com/rpc/v1/base/CthFLRfCqMHXaNqlBwQ85S7SVjbUGBy5";
        var web3 = new Web3(rpcUrl);
        int furNo = 0;

        // Check connection
        bool isConnected = await web3.Eth.Blocks.GetBlockNumber.SendRequestAsync() != null;
        if (!isConnected)
        {
            Console.WriteLine("Failed to connect to Ethereum node.");
            return 0;
        }

        // Cat town game contract
        string contractAddress = "0x10A77395a07917C5Eb71fEEB86696B7612f9730F";
        string abi = @"[
            {
                ""constant"": true,
                ""inputs"": [{""name"": ""addr"", ""type"": ""address""}],
                ""name"": ""getFurballsSinceLastGrowth"",
                ""outputs"": [{""name"": """", ""type"": ""uint256""}],
                ""payable"": false,
                ""stateMutability"": ""view"",
                ""type"": ""function""
            }
        ]";

        // Address to test
        //string testAddress = "0x8519081783C375Da414F8187c286fFF0d60b09F7";

        try
        {
            // Load the contract
            var contract = web3.Eth.GetContract(abi, contractAddress);

            // Get the `cats` function
            var furFunction = contract.GetFunction("getFurballsSinceLastGrowth");

            // Call the function
            furNo = await furFunction.CallAsync<int>(addr);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error calling function: {ex.Message}");
        }
        
        return furNo;
    }
    
    //getPlayerBoostBreakdown(addr)

    public static async Task<float> GetTotalBonusesAsync(string addr)
    {
        string rpcUrl = "https://api.developer.coinbase.com/rpc/v1/base/CthFLRfCqMHXaNqlBwQ85S7SVjbUGBy5";
        var web3 = new Web3(rpcUrl);
        float furNo = 0f;

        // Check connection
        bool isConnected = await web3.Eth.Blocks.GetBlockNumber.SendRequestAsync() != null;
        if (!isConnected)
        {
            Console.WriteLine("Failed to connect to Ethereum node.");
            return 0;
        }

        // Cat town game contract
        string contractAddress = "0x10A77395a07917C5Eb71fEEB86696B7612f9730F";
        string abi = @"[{'constant':true,'inputs':[{'name':'user','type':'address'}],
                'name':'getPlayerBoostBreakdown','outputs':[{'name':'floofBonuses','type':'tuple',
                'components':[{'name':'totalBoost','type':'uint256'},
                              {'name':'fanTokenBoost','type':'uint256'},
                              {'name':'pfpNFTBoost','type':'uint256'},
                              {'name':'stakedKibbleBoost','type':'uint256'}]}],
                'type':'function'}]";

        // Address to test
        //string testAddress = "0x8519081783C375Da414F8187c286fFF0d60b09F7";

        try
        {
            // Load the contract
            var contract = web3.Eth.GetContract(abi, contractAddress);

            var boostFunction = contract.GetFunction("getPlayerBoostBreakdown");
            
            var bonusStruct = await boostFunction.CallDeserializingToObjectAsync<FloofBonuses>(addr);
            
            furNo = (float)bonusStruct.totalBoost;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error calling function: {ex.Message}");
        }
        
        return furNo;
    }
}