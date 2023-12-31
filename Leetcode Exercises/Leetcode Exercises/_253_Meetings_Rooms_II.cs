﻿//****************************************************
// Each file will have one problem and there will be a  
//      matching NUnit tests to verify the tests pass.
// Each exercise question will have the following information 
//      in its header
//     Runtime:
//     Memory:  (might not include this...)
//     Link:
//****************************************************

// https://leetcode.com/problemset/all/?premium=true&page=1&sorting=W3sic29ydE9yZGVyIjoiREVTQ0VORElORyIsIm9yZGVyQnkiOiJGUkVRVUVOQ1kifV0%3D
namespace Leetcode_Exercises
{

    /// <summary>
    /// Given an array of meeting time intervals intervals where intervals[i] = [starti, endi], return the minimum number of conference rooms required.
    ///     Example 1:
    /// 
    ///     Input: intervals = [[0,30],[5,10],[15,20]]
    ///     Output: 2
    ///     Example 2:
    /// 
    ///     Input: intervals = [[7,10],[2,4]]
    ///     Output: 1
    ///     
    /// Constraints:
    /// 
    ///     1 <= intervals.length <= 104
    ///     0 <= starti < endi <= 106
    ///     
    /// Link: https://leetcode.com/problems/meeting-rooms-ii/
    /// </summary>
    public class _253_Meetings_Rooms_II
    {
        /// <summary>
        ///
        /// </summary>
        public int MinMeetingRooms(int[][] intervals)
        {

            // Thoughts...there's no need to sort the array, because we're just looking for what is available..
            // so the solution is just to treat the array values as ranges and look for overlaps 
            // In theory, I need to come up with three cases
            // 1) The start time is before the current min time 
            // 2) The time starts and ends within t

            Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));

            int rooms = 1;
            int freeRoomCount = 1;
            int currTime = 0;

            PriorityQueue<int[], int> occupiedRooms = new PriorityQueue<int[], int>();

            foreach (int[] interval in intervals)
            {
                int startTime = interval[0];
                int endTime = interval[1];

                currTime = Math.Max(currTime, startTime);

                while (occupiedRooms.Count > 0 && occupiedRooms.Peek()[1] <= currTime)
                {
                    occupiedRooms.Dequeue();
                    freeRoomCount++;
                }

                if (freeRoomCount == 0)
                {
                    rooms++;
                    freeRoomCount++;
                }

                freeRoomCount--;
                int newStartTime = currTime;
                int newEndTime = currTime + (endTime - startTime);

                occupiedRooms.Enqueue(new int[] { newStartTime, newEndTime }, newEndTime);
            }

            return rooms;
        }
    }
}
