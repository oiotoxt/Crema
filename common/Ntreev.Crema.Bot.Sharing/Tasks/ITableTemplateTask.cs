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

using Ntreev.Crema.Data;
using Ntreev.Crema.ServiceModel;
using Ntreev.Crema.Services;
using Ntreev.Library;
using Ntreev.Library.Random;
using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Text;
using System.Threading.Tasks;

namespace Ntreev.Crema.Bot.Tasks
{
    [Export(typeof(ITaskProvider))]
    [Export(typeof(ITableTemplateTask))]
    [TaskClass]
    public class ITableTemplateTask : ITaskProvider
    {
        public void InvokeTask(TaskContext context)
        {
            var template = context.Target as ITableTemplate;
            template.Dispatcher.Invoke(() =>
            {
                if (context.IsCompleted(template) == true)
                {
                    try
                    {
                        if (Verify() == true)
                        {
                            template.EndEdit(context.Authentication);
                        }
                    }
                    catch
                    {
                        template.CancelEdit(context.Authentication);
                    }

                    context.Pop(template);
                    context.Complete(context.Target);
                }
                else
                {
                    if (template.Domain == null)
                        template.BeginEdit(context.Authentication);
                    if (template.IsNew == true || template.Any() == false || RandomUtility.Within(25) == true)
                    {
                        var column = template.AddNew(context.Authentication);
                        context.Push(column);
                        context.State = System.Data.DataRowState.Detached;
                    }
                    else
                    {
                        var member = template.Random();
                        context.Push(member);
                    }
                }
            });

            bool Verify()
            {
                if (context.AllowException == true)
                    return true;
                if (template.Domain == null)
                    return false;
                if (template.Any(item => item.IsKey) == false)
                    return false;
                return true;
            }
        }

        public Type TargetType
        {
            get { return typeof(ITableTemplate); }
        }

        public bool IsEnabled
        {
            get { return false; }
        }

        [TaskMethod(Weight = 10)]
        public void SetTableName(ITableTemplate template, TaskContext context)
        {
            template.Dispatcher.Invoke(() =>
            {
                var tableName = RandomUtility.NextIdentifier();
                template.SetTableName(context.Authentication, tableName);
            });
        }

        [TaskMethod(Weight = 10)]
        public void SetTags(ITableTemplate template, TaskContext context)
        {
            template.Dispatcher.Invoke(() =>
            {
                var tags = (TagInfo)TagInfoUtility.Names.Random();
                template.SetTags(context.Authentication, tags);
            });
        }

        [TaskMethod(Weight = 10)]
        public void SetComment(ITableTemplate template, TaskContext context)
        {
            template.Dispatcher.Invoke(() =>
            {
                var comment = RandomUtility.NextString();
                template.SetComment(context.Authentication, comment);
            });
        }
    }
}
