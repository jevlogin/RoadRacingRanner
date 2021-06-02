using DG.Tweening;

namespace JevLogin
{
    internal interface ISidePanelElementTween
    {
        void GoToEnd(MoveMode mode);
        Sequence Move(MoveMode mode, float timeScale);
    }
}