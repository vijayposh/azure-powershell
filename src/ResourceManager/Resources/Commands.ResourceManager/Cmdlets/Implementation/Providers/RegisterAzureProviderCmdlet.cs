﻿// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System;

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation
{
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels;
    using System.Management.Automation;
    using ProjectResources = Microsoft.Azure.Commands.ResourceManager.Cmdlets.Properties.Resources;

    /// <summary>
    /// Register the previewed features of a certain azure resource provider.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Register, "AzureRmResourceProvider", SupportsShouldProcess = true), OutputType(typeof(PSResourceProvider))]
    public class RegisterAzureProviderCmdlet : ResourceManagerCmdletBase
    {
        /// <summary>
        /// Gets or sets the provider namespace
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource provider namespace.")]
        [ValidateNotNullOrEmpty]
        public string ProviderNamespace { get; set; }

        /// <summary>
        /// Gets or sets a switch that indicates if the user should be prompted for confirmation.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Do not ask for confirmation.")]
        [Obsolete("The Force parameter will be removed in a future release.", false)]
        public SwitchParameter Force { get; set; }

        /// <summary>
        /// Executes the cmdlet
        /// </summary>
        public override void ExecuteCmdlet()
        {
            this.ConfirmAction(
                processMessage: ProjectResources.RegisterProviderMessage,
                target: this.ProviderNamespace,
                action: () => this.WriteObject(this.ResourceManagerSdkClient.RegisterProvider(providerName: this.ProviderNamespace)));
        }
    }
}