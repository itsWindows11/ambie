﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AmbientSounds.Services
{
    public interface IFocusService
    {
        /// <summary>
        /// Triggered when the time remaining changes.
        /// </summary>
        event EventHandler<FocusSession>? TimeUpdated;

        /// <summary>
        /// Triggered when the <see cref="CurrentState"/> changes.
        /// </summary>
        event EventHandler<FocusState>? FocusStateChanged;

        /// <summary>
        /// Gets the current state of the focus service. 
        /// </summary>
        FocusState CurrentState { get; }

        /// <summary>
        /// Calculates the total time for the given
        /// parameters of a session.
        /// </summary>
        /// <param name="focusLength">The length of each focus segment.</param>
        /// <param name="restLength">The length of each rest segment.</param>
        /// <param name="repetitions">The number of times to repeat. A value of zero means that the session will only run once.</param>
        /// <returns>The total time a focus session will take.</returns>
        TimeSpan GetTotalTime(int focusLength, int restLength, int repetitions);

        /// <summary>
        /// Pauses the given focus session.
        /// </summary>
        void PauseTimer();

        /// <summary>
        /// Resumes the current active focus session.
        /// </summary>
        /// <returns>True if session was successfully resumed. False, otherwise.</returns>
        bool ResumeTimer();

        /// <summary>
        /// Starts new focus session given the following parameters.
        /// </summary>
        /// <returns>True if session was successfully started. False, otherwise.</returns>
        bool StartTimer(int focusLength, int restLength, int repetitions);

        /// <summary>
        /// Stops the current focus session and resets.
        /// </summary>
        void StopTimer();

        /// <summary>
        /// Determines the number of repetitions remaining in the current
        /// focus session.
        /// </summary>
        /// <param name="session">The currently active focus segment.</param>
        /// <returns>The number of repetitions remaining.</returns>
        int GetRepetitionsRemaining(FocusSession session);

        /// <summary>
        /// Determines if the session can be started
        /// with the given parameters.
        /// </summary>
        bool CanStartSession(int focusLength, int restLength);
    }
}
