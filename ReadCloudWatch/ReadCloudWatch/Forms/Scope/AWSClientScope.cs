using Amazon;
using Amazon.CloudWatchLogs;
using Amazon.Runtime;
using Amazon.Runtime.CredentialManagement;
using System;

namespace ReadCloudWatch.Forms.Scope
{
    internal class AWSClientScope : IDisposable
    {
        #region Private Fields

        private static AWSCredentials _credentials;
        private readonly RegionEndpoint currentRegion;

        #endregion Private Fields

        #region Private Properties

        private static AWSCredentials Credentials
        {
            get
            {
                if(_credentials != null)
                {
                    return _credentials;
                }

                var chain = new CredentialProfileStoreChain();
                chain.TryGetAWSCredentials("Marcelo", out _credentials);
                return _credentials;
            }
        }

        #endregion Private Properties

        #region Public Properties

        public static AWSClientScope Instance { get; private set; }
        public IAmazonCloudWatchLogs Client { get; private set; }

        #endregion Public Properties

        #region Public Constructors

        public AWSClientScope(RegionEndpoint region)
        {
            if(Instance != null)
            {
                throw new InvalidOperationException("Já existe um escopo definido.");
            }

            currentRegion = region ?? throw new ArgumentNullException(nameof(region));
            Client = new AmazonCloudWatchLogsClient(Credentials, currentRegion);
            Instance = this;
        }

        #endregion Public Constructors

        #region Public Methods

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            Client.Dispose();
            Instance = null;
            Client = null;
        }

        #endregion Public Methods
    }
}