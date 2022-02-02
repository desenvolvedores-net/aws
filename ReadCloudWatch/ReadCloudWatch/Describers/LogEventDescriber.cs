using Amazon.CloudWatchLogs.Model;
using ReadCloudWatch.Describers.Contract;
using ReadCloudWatch.Forms.Scope;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReadCloudWatch.Describers
{
    internal class LogEventDescriber : IDescriber<OutputLogEvent>
    {
        #region Public Properties

        public GetLogEventsRequest EventsRequest { get; }

        #endregion Public Properties

        #region Public Constructors

        public LogEventDescriber(GetLogEventsRequest eventsRequest) => EventsRequest = eventsRequest;

        #endregion Public Constructors

        #region Public Methods

        public async Task FillNodeAsync(TreeNode node)
        {
            foreach(var log in await GetItemsAsync())
            {
                var nd = new TreeNode(log.Message)
                {
                    Tag = log
                };

                node.Nodes.Add(nd);
            }

            node.Expand();

            await Task.CompletedTask;
        }

        public async Task<IEnumerable<OutputLogEvent>> GetItemsAsync()
        {
            var result = (await AWSClientScope.Instance.Client.GetLogEventsAsync(EventsRequest)).Events;

            if(result.Count == 0)
            {
                return new OutputLogEvent[] {
                    new OutputLogEvent
                    {
                        Timestamp = EventsRequest.EndTime,
                        Message = EventsRequest.LogStreamName
                    }};
            }

            return result;
        }

        #endregion Public Methods
    }
}