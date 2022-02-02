using Amazon;
using ReadCloudWatch.Describers.Contract;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReadCloudWatch.Describers
{
    internal class RegionDescriber : IDescriber<RegionEndpoint>
    {
        #region Public Methods

        public async Task FillNodeAsync(TreeNode node)
        {
            foreach(var region in await GetItemsAsync())
            {
                var nd = new TreeNode(region.DisplayName)
                {
                    Tag = region
                };

                node.Nodes.Add(nd);
            }

            node.Expand();

            await Task.CompletedTask;
        }

        public async Task<IEnumerable<RegionEndpoint>> GetItemsAsync()
        {
            await Task.CompletedTask;
            return RegionEndpoint.EnumerableAllRegions;
        }

        #endregion Public Methods
    }
}