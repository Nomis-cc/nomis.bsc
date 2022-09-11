namespace Nomis.Bscscan.Interfaces.Models
{
    /// <summary>
    /// Bsc wallet score.
    /// </summary>
    public class BscWalletScore
    {
        /// <summary>
        /// Nomis Score in range of [0; 1].
        /// </summary>
        public double Score { get; set; }

        /// <summary>
        /// Additional stat data used in score calculations.
        /// </summary>
        public BscWalletStats? Stats { get; set; }
    }
}