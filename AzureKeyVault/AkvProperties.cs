﻿// Copyright 2023 Keyfactor
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

namespace Keyfactor.Extensions.Orchestrator.AzureKeyVault
{
    public class AkvProperties
    {
        public string SubscriptionId { get; set; }
        public string ClientId { get; set; } // (a.k.a. ClientId)
        public string ClientSecret { get; set; }
        public string TenantId { get; set; }
        public string ResourceGroupName { get; set; }
        public string VaultName { get; set; }
        public string StorePath { get; set; }
        public string VaultRegion { get; set; }
        public bool PremiumSKU { get; set; }
        internal protected bool UseAzureManagedIdentity
        {
            get
            {
                return string.IsNullOrEmpty(ClientSecret) || ClientSecret.ToLowerInvariant() == "managed"; 
                // if they don't provide a client secret, assume they are using Azure Managed Identities
                // if they provide a client id, but "managed" for the secret, they are using a user assigned managed identity.
            }
        }

        internal protected string VaultURL => $"https://{VaultName}.vault.azure.net/";
    }
}
