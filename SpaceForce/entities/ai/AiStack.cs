using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace SpaceForce.Desktop.entities.ai {
  public class AiStack {

		private List<Ai> stack = new List<Ai>();
		private Ai runningTask;
		private int taskUpdateTimer = 0;

		public void Add(Ai ai) {
			stack.Add(ai);
		}

		public void RethinkCurrentTask() {
			var canidate = runningTask;

			foreach (Ai ai in stack) {
				if (ai.IsMoreImporantThan(canidate) && ai.ShouldExecute()) {
					canidate = ai;
				}
			}

			if (!Object.ReferenceEquals(canidate, runningTask)) StartNewTask(canidate);
		}

		private void StartNewTask(Ai ai) {
			runningTask = ai;
			runningTask.Start();
		}
    
		public void Update(GameTime gameTime) {
			if (taskUpdateTimer < 1) {
				RethinkCurrentTask();
				taskUpdateTimer = 50;
			}
			if (runningTask != null) {
				if (!runningTask.Update(gameTime)) {
					runningTask = null;
					RethinkCurrentTask();
				}
			}
			taskUpdateTimer--;
    }

  }
}
