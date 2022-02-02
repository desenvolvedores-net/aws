using Amazon.CloudWatchLogs.Model;
using ReadCloudWatch.Describers.Contract;
using ReadCloudWatch.Forms.Scope;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReadCloudWatch.Describers
{
    internal class LogGroupDescriber : IDescriber<LogGroup>
    {
        #region Public Methods

        public async Task FillNodeAsync(TreeNode node)
        {
            foreach(var group in await GetItemsAsync())
            {
                var nodeGroup = new TreeNode(group.LogGroupName)
                {
                    Tag = group,
                };

                node.Nodes.Add(nodeGroup);
            }

            node.Expand();
        }

        public async Task<IEnumerable<LogGroup>> GetItemsAsync() =>
            (await AWSClientScope.Instance.Client.DescribeLogGroupsAsync()).LogGroups.OrderBy(o => o.LogGroupName);

        #endregion Public Methods
    }
}