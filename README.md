Introduction
=======

![Try Ruby right inside your Windows Phone](https://cloud.githubusercontent.com/assets/132692/4947725/dd4276a2-666b-11e4-9f30-5301ed8028f2.jpg)

As a Ruby hobbyist, you might have heard of tryruby.org originally created by [why the lucky stiff](http://en.wikipedia.org/wiki/Why_the_lucky_stiff), a great learning tool that enables you to try Ruby inside your browser. Have you ever dreamed of evaluating Ruby expressions right inside your Windows Phone, just like texting inside the Messaging Hub? You've come to the right place. Have fun with Ruby!

Features
=======

This app is still in BETA stage, and only for study and experiment at this point of time. Here's a list of what I plan to implement:

1. Copy previous expressions/results [done]
2. Multi-line code scenarios [done]
3. Save user-defined code
4. Learning mode

**1.0 BETA (2014-11-7):**

1. Basic [REPL](http://en.wikipedia.org/wiki/Read%E2%80%93eval%E2%80%93print_loop) for single-line expressions [done]
2. [Messaging Hub](http://www.windowsphone.com/en-us/how-to/wp8/calling-and-messaging/send-a-text) style texting [done]
3. Error handling for input code [done]
4. Format result object like irb [done]
5. Help and learning materials [done]

Build and run
=======
This app is now available in [Windows Phone Store](http://www.windowsphone.com/en-us/store/app/try-ruby-beta/56df56a6-ce3b-4be3-a7eb-d291cf309dbb). You can also download it by scanning the QR code in the above poster.

To build and run lastest TryRuby from source code, you'll need [Windows Phone SDK 8.0](http://dev.windows.com/en-us/develop/download-phone-sdk) or higher. This project is brought to reality thanks to [DLR 1.0](https://github.com/IronLanguages/dlr) and [IronRuby 1.3.1](http://ironruby.net) which is compatible with Ruby 1.9.2. The source code is licensed under MIT License.

References
=======

- [Dynamic Language Runtime docs and specs](https://dlr.codeplex.com/wikipage?title=Docs%20and%20specs&referringTitle=Documentation)
- [Pro DLR in .NET 4](http://www.amazon.com/Pro-DLR-NET-Experts-Voice/dp/1430230665)
- [IronRuby Unleashed](http://www.amazon.com/IronRuby-Unleashed-Shay-Friedman/dp/0672330784)
- [Ruby in the browser documentation](http://ironruby.net/browser/docs.html)
