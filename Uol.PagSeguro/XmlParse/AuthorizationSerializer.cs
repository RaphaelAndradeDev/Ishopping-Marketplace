// Copyright [2011] [PagSeguro Internet Ltda.]
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitation

using System;
using System.Collections.Generic;
using System.Xml;
using Uol.PagSeguro.Constants;
using Uol.PagSeguro.Domain.Authorization;

namespace Uol.PagSeguro.XmlParse
{
    /// <summary>
    /// 
    /// </summary>
    internal static class AuthorizationSerializer
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="authorization">PagSeguro AuthorizationResponse</param>
        internal static void Read(XmlReader reader, AuthorizationResponse authorization)
        {

            if (reader.IsEmptyElement)
            {
                XMLParserUtils.SkipNode(reader);
                return;
            }

            reader.ReadStartElement(); 
            reader.MoveToContent();

            while (!reader.EOF)
            {

                if (XMLParserUtils.IsEndElement(reader, SerializerHelper.PreApproval))
                {
                    XMLParserUtils.SkipNode(reader);
                    break;
                }

                if (reader.NodeType == XmlNodeType.Element)
                {
                    switch (reader.Name)
                    {
                        case SerializerHelper.Code:
                            authorization.Code = reader.ReadElementContentAsString();
                            break;
                        case SerializerHelper.Date:
                            authorization.Date = reader.ReadElementContentAsDateTime();
                            break;
                    }
                }
                else
                {
                    XMLParserUtils.SkipNode(reader);
                }
            }
        }
    }
}
