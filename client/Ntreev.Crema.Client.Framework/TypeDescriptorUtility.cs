﻿//Released under the MIT License.
//
//Copyright (c) 2018 Ntreev Soft co., Ltd.
//
//Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated 
//documentation files (the "Software"), to deal in the Software without restriction, including without limitation the 
//rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit 
//persons to whom the Software is furnished to do so, subject to the following conditions:
//
//The above copyright notice and this permission notice shall be included in all copies or substantial portions of the 
//Software.
//
//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE 
//WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR 
//COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR 
//OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

using Ntreev.Crema.Client.Framework.Dialogs.ViewModels;
using Ntreev.Crema.Client.Framework.Properties;
using Ntreev.Crema.ServiceModel;
using Ntreev.Crema.Services;
using Ntreev.ModernUI.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Ntreev.Crema.Client.Framework
{
    public static class TypeDescriptorUtility
    {
        public static bool IsBeingEdited(Authentication authentication, ITypeDescriptor descriptor)
        {
            if (authentication == null)
                throw new ArgumentNullException(nameof(authentication));
            if (descriptor == null)
                throw new ArgumentNullException(nameof(descriptor));
            return descriptor.TypeState.HasFlag(TypeState.IsBeingEdited);
        }

        public static bool IsBeingEditedClient(Authentication authentication, ITypeDescriptor descriptor)
        {
            if (authentication == null)
                throw new ArgumentNullException(nameof(authentication));
            if (descriptor == null)
                throw new ArgumentNullException(nameof(descriptor));
            return descriptor.TypeState.HasFlag(TypeState.IsBeingEdited | TypeState.IsMember);
        }

        public static bool IsFlag(Authentication authentication, ITypeDescriptor descriptor)
        {
            if (authentication == null)
                throw new ArgumentNullException(nameof(authentication));
            if (descriptor == null)
                throw new ArgumentNullException(nameof(descriptor));
            return descriptor.TypeInfo.IsFlag;
        }

        //public static bool IsBeingSetup(Authentication authentication, ITypeDescriptor descriptor)
        //{
        //    if (authentication == null)
        //        throw new ArgumentNullException(nameof(authentication));
        //    if (descriptor == null)
        //        throw new ArgumentNullException(nameof(descriptor));
        //    return descriptor.TypeState.HasFlag(TypeState.IsBeingSetup);
        //}

        //public static bool IsBeingSetupClient(Authentication authentication, ITypeDescriptor descriptor)
        //{
        //    if (authentication == null)
        //        throw new ArgumentNullException(nameof(authentication));
        //    if (descriptor == null)
        //        throw new ArgumentNullException(nameof(descriptor));
        //    return descriptor.TypeState.HasFlag(TypeState.IsBeingSetup | TypeState.IsMember);
        //}

        //public static bool IsInherited(Authentication authentication, ITypeDescriptor descriptor)
        //{
        //    if (authentication == null)
        //        throw new ArgumentNullException(nameof(authentication));
        //    if (descriptor == null)
        //        throw new ArgumentNullException(nameof(descriptor));
        //    return descriptor.TypeInfo.TemplatedParent != string.Empty;
        //}

        //public static bool IsBaseTemplate(Authentication authentication, ITypeDescriptor descriptor)
        //{
        //    if (authentication == null)
        //        throw new ArgumentNullException(nameof(authentication));
        //    if (descriptor == null)
        //        throw new ArgumentNullException(nameof(descriptor));
        //    return descriptor.TypeAttribute.HasFlag(TypeAttribute.BaseType);
        //}
    }
}
