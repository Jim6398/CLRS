using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointerImplementationBy3Arrays
{
    interface ILinkedListWithPointer
    {

        void InitializeFree();

        /// <summary>
        /// Allocate a space for object
        /// </summary>
        /// <returns></returns>
        int AllocateObject();

        /// <summary>
        /// Free a object
        /// </summary>
        /// <returns></returns>
        void FreeObject(int index);

        /// <summary>
        /// Delete the specified Value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        void Delete(int value);

        /// <summary>
        /// Insert value to the LinkedList
        /// </summary>
        /// <param name="value"></param>
        void Insert(int value);

        void PrintArray();
    }
}
