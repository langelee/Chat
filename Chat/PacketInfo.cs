﻿#region License Information (GPL v3)

/*
    Copyright (C) Jaex

    This program is free software; you can redistribute it and/or
    modify it under the terms of the GNU General Public License
    as published by the Free Software Foundation; either version 2
    of the License, or (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program; if not, write to the Free Software
    Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.

    Optionally you can also view the license at <http://www.gnu.org/licenses/>.
*/

#endregion License Information (GPL v3)

using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Chat
{
    public class PacketInfo
    {
        public string Command { get; set; }
        public Dictionary<string, string> Parameters { get; set; }
        public object Data { get; set; }

        public PacketInfo(string command)
        {
            Command = command;
        }

        public void AddParameter(string name, string value)
        {
            if (Parameters == null)
            {
                Parameters = new Dictionary<string, string>();
            }

            Parameters.Add(name, value);
        }

        public string GetParameter(string name, string defaultValue = "")
        {
            if (Parameters != null && Parameters.ContainsKey(name))
            {
                return Parameters[name];
            }

            return defaultValue;
        }

        public T GetData<T>()
        {
            JToken obj = Data as JToken;

            if (obj != null)
            {
                return obj.ToObject<T>();
            }

            return default(T);
        }
    }
}