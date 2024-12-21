using System.Numerics;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace CatTownCalc.Model;


[FunctionOutput]
public class FloofBonuses
{
    [Parameter("uint256", "stakeKibbleBoost", 1)]
    public BigInteger stakedKibbleBoost { get; set; }
    
    [Parameter("uint256", "fanTokenBoost", 2)]
    public BigInteger fanTokenBoost { get; set; }
    
    [Parameter("uint256", "pfpNFTBoost", 3)]
    public BigInteger pfpNFTBoost { get; set; }
    
    [Parameter("uint256", "totalBoost", 4)]
    public BigInteger totalBoost { get; set; }
}