# HabitFY-API

## What is HabitFY?

## Tech stack 


## Work flow

Main is protected. A topic branch requires two members to approve before it merges to the main. ( For example, Sujan is trying to merge his feature branch to the main, and he of course will approve it. But it is not enough, he also needs either Anson or Amit or myself to approve so the PR can be merged. ) 

Main will have CI/CD pipelines built up and unit tests when the project is appoaching to the end. 

Dev is not protected, you are asked to merged your topic branch to the dev first, and then test it on your station. 

Then merge the dev to the main to bring the changes from dev to the main. 

So the flow works like:

Topic Branch -> Dev -> Main
            PR      PR
