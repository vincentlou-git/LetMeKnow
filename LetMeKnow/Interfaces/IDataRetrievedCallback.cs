using System;
using System.Collections.Generic;
using System.Text;

namespace LetMeKnow.Interfaces
{
    // https://stackoverflow.com/questions/47847694/how-to-return-datasnapshot-value-as-a-result-of-a-method
    public interface IDataRetrievedCallback<T> {
        void OnCallback(T data);
    }
}
