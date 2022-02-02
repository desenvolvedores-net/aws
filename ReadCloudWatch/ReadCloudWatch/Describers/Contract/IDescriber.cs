using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReadCloudWatch.Describers.Contract
{
    internal interface IDescriber<TItem>
    {
        #region Public Methods

        Task FillNodeAsync(TreeNode node);

        Task<IEnumerable<TItem>> GetItemsAsync();

        #endregion Public Methods
    }
}