/*
 * https://leetcode.com/problems/strong-password-checker/
	A password is considered strong if below conditions are all met:
	It has at least 6 characters and at most 20 characters.
	It must contain at least one lowercase letter, at least one uppercase letter, and at least one digit.
	It must NOT contain three repeating characters in a row ("...aaa..." is weak, but "...aa...a..." is strong, assuming other conditions are met).
	Write a function strongPasswordChecker(s), that takes a string s as input, and return the MINIMUM change required to make s a strong password. If s is already strong, return 0.

Insertion, deletion or replace of any one character are all considered as one change.

 */


namespace Algorithms.HackerRank
{
    using System;
    using Algorithms.Searching;

    class SelfCrossing 
    {

        public static int solve(int[] x) {
            // see picture from notebook for solution idea. We showed that no matter what x contained up 
            // x[i] (assuming it has not yet crossed), then there is an equivalent analysis that can be
            // done using only x[i] ... x[i - 3]. Thus, we store a int[4] buffer (technically O(1)) to track
            // the last 4 of x
            return 1;
		}
    }
}
