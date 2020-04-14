/*
    Schedule MIREA in calendar.
    Copyright (C) 2020  
    Mikhail Pavlovich Sidorenko (motherlode.muwa@gmail.com)
    George Andreevich Falileev

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/

/*
Файл указывает правило, какие данные будут переданы клиенту.
 */

using System.IO;
using System;
using System.Runtime.Serialization.Formatters.Binary;

namespace ru.mirea.xlsical.interpreter
{
    [Serializable]
    public class PackageToClient : Package
    {
        /// <summary>
        /// Путь до файла *.ics.
        /// </summary>
        public readonly string CalFile;

        /// <summary>
        /// Количество созданных мероприятий.
        /// </summary>
        public readonly int Count;

        /// <summary>
        /// Сообщение от сервера. Например: "Найдено несколько преподавателей с этим именем: Иванов И.И. и Иванов И.А."
        /// </summary>
        public readonly string Messages;

        /// <summary>
        /// Строит данные отправляемые на клиент.
        /// </summary>
        /// <param name="context">Уникальный идентификатор сообщения или его контекст.</param>
        /// <param name="CalFile">Путь до файла *.ics.</param>
        /// <param name="Count">Количество созданных мероприятий.</param>
        /// <param name="Messages">Сообщение от обработчика пользователю клиента.</param>
        public PackageToClient(object context, string CalFile, int Count, string Messages)
        : base(context)
        {
            this.CalFile = CalFile;
            this.Count = Count;
            this.Messages = Messages;
        }

        /// <summary>
        /// Преобразует входящий массив байтов в текущее хранилище.
        /// </summary>
        /// <param name="input">Массив байтов, который необходимо перевести в текущий класс.</param>
        /// <returns>Представление хранилища в классе PackageToClient. Если ошибка, то null.</returns>
        /// <exception cref="System.InvalidCastException">Тип данных подменён.</exception>
        /// <exception cref="System.IO.IOException">Тип данных подменён.</exception>
        public static PackageToClient fromByteArray(byte[] input)
        {
            using MemoryStream stream = new MemoryStream(input);
            return (PackageToClient)new BinaryFormatter().Deserialize(stream);
        }

        public override string ToString()
        {
            return "PackageToClient{" +
                    "CalFile='" + CalFile + '\'' +
                    ", Count=" + Count +
                    ", Messages='" + Messages + '\'' +
                    '}';
        }
    }
}
