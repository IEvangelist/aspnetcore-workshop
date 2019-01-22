---
title: "Github"
weight: 4
---

## <i class='fab fa-github'></i> GitHub

Now that we have a project that not only successfully compiles but also executes error free - we should persist our work. We'll rely on <i class='fab fa-github'></i> __GitHub__ to do so. I prefer to use the __Git CLI__, specifically the <a href='https://git-scm.com/download/win' target=''_blank>Git for Windows</a> Command Line. I do know that __Visual Studio__ has builtin integration with GitHub - the choice is yours. Let's setup our <i class='fab fa-github'></i> __GitHub__ repository such that we can persist our working application.

 1. Navigate to your <i class='fab fa-github'></i> __GitHub__ https://github.com/new
 1. Create a new repository with the same name as our project `AspNet.Essentials.Workshop`
 1. Do __not__ change any other settings:
   1. Leave as _Public_ 
   1. Leave the _"Initialize this repository with a README"_ unchecked
   1. Do __not__ add a `.gitignore`
   1. Do __not__ add a license
 1. Click the __Create repository__ button

![New Repo](/1-introduction/github/images/new-repo.png?classes=border,shadow)

Now we need to copy the URL of our remote repository.

![Copy Repo](/1-introduction/github/images/copy-repo.png?classes=border,shadow)

In the `File Explorer` navigate to the root directory of your newly created project - at the `.sln` level. From their launch the __Git CLI__. The repo should have already been initialized - we simply need to map our `upstream`. Type the following command - but replace the last argument with your unique URL.

```
git remote add upstream https://github.com/IEvangelist/AspNet.Essentials.Workshop.git
```

You can then verify that this was done correctly, by executing `git remote -v` and viewing what is configured.

![Git Remote](/1-introduction/github/images/git-remote.png?classes=border,shadow)

Finally, we'll __add__ our changes, __commit__ them and then __push__ everything upstream. This will be our standard development workflow. At anytime you can `git status` to view the current state of things.

```
git add -A
```

This will add all pending changes to staging.

```
git commit -m "Some reasonable description of what we're doing."
```

This will commit all of the staged changes with the given commit message.

```
git push upstream master
```

This will push all of our local commits upstream to our remote repository.

![Git Remote](/1-introduction/github/images/git-flow.png?classes=border,shadow)