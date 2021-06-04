using Core.DataComponents;
using UnityEngine;

namespace Core.InteractionHandler {
	public interface IHandler {
		IHandler SetNext(IHandler handler);
		GameObject Handle(GameObject other);
	}

	public abstract class AbstractHandler : MonoBehaviour, IHandler {
		private IHandler _nextHandler;

		public IHandler SetNext(IHandler handler) {
			_nextHandler = handler;
			return handler;
		}

		public virtual GameObject Handle(GameObject other) {
			if (_nextHandler != null) {
				return _nextHandler.Handle(other);
			}

			return null;
		}
	}

	public class BarrierHandler : AbstractHandler {
		public override GameObject Handle(GameObject other) {
			if (CheckBarrier(other)) {
				return base.Handle(other);
			}

			return null;
		}

		private bool CheckBarrier(GameObject other) {
			if (other.TryGetComponent(out ResourceComponent resourceComponent)) {
				return true;
			}

			return false;
		}
	}
}