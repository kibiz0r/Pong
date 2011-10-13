# Why TDD?

## Adapting to changing features
Changing a feature is different from adding a feature. When you add a feature, you're going from not having the feature to having the feature, which is about as straightforward as software development gets.

Changing a feature, on the other hand, means taking something that already works and making it work in a different way. When every line of code you're writing is new and fresh in your mind, you have your most nuanced view of it.

When you come back later to change a subset of the feature, you might find yourself paralyzed as you try to recall how it all fits together and whether it's really okay to change the FooBars to Voltrons, or the code has rotted so badly that it's hard to work with any of it, or that nobody is around who wrote the original implementation.

It might not even be that old, but you've built up this epic class hierarchy based on some key assumptions about the problem domain -- assumptions that just got thrown out the window.

If you refactor it, how are you going to be sure that the existing code still works?
If you don't refactor it, how far can you push this minor tweaks before you end up totally invalidating the system's design?

In this situation, a test suite is like a life raft in a big, scary ocean.

## It's a payment plan for technical debt

> Technical Debt is a wonderful metaphor developed by Ward Cunningham to help us think about this problem. In this metaphor, doing things the quick and dirty way sets us up with a technical debt, which is similar to a financial debt. Like a financial debt, the technical debt incurs interest payments, which come in the form of the extra effort that we have to do in future development because of the quick and dirty design choice. We can choose to continue paying the interest, or we can pay down the principal by refactoring the quick and dirty design into the better design. Although it costs to pay down the principal, we gain by reduced interest payments in the future.

> The metaphor also explains why it may be sensible to do the quick and dirty approach. Just as a business incurs some debt to take advantage of a market opportunity developers may incur technical debt to hit an important deadline. The all too common problem is that development organizations let their debt get out of control and spend most of their future development effort paying crippling interest payments.

Despite our best efforts, software accrues technical debt over time. As we implement new features, change existing features, fix bugs, adopt new technologies, and so on, the codebase starts to rot.

Realize that this is not happening in some distant future where someone else has to deal with the consequences, but right now as you make changes to your code. If you allow gross code to persist in your codebase, you'll soon find it impossible to make any changes reliably.

TDD isn't an inoculation against technical debt, but it at least slows its growth. Making a serious effort at TDD should make it harder for bad designs to make their way in, and should make it easier to pay down the debt when it does happen.

Initially, you may find that writing tests takes longer and seems to be slowing you down, but as the codebase grows in complexity, it still remains just about easy to change, rather than getting drastically more difficult as we see in most software projects.

## 