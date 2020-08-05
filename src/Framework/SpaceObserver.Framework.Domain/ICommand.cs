namespace SpaceObserver.Framework.Domain
{
    using System;

    public interface ICommand
    {
        int CommandVersion { get; }
    
        DateTime CreatedOn { get; }
    }
}