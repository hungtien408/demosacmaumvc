﻿!function (s) { s.fn.extend({ menulevel: function (a) { var i = { csscurrent: "current", cssopne: "open", cssactive: "active", datalevel: "data-level", iconsa: !1, cssicon: !1, cssdown: "icon-caret-down", cssup: "icon-caret-up" }, a = s.extend(i, a); return this.each(function () { var i = a, n = s(this), t = s("a", n), e = s("li", n), c = s("." + i.cssactive, n); i.iconsa ? e.filter(":has('ul li')").find("a:first").attr("href", "javascript:void(0);").append('<span class="iconr iconadown"></span><span class="iconr iconaup"></span>') : e.filter(":has('ul li')").find("a:first").attr("href", "javascript:void(0);"), i.cssicon && (t.find(".iconadown").addClass(i.cssdown), t.find(".iconaup").addClass(i.cssup)), t.click(function () { var a = s(this).parent("li").parent("ul").attr(i.datalevel); s("ul[" + i.datalevel + "='" + a + "'] > li").removeClass(i.csscurrent), s(this).toggleClass(i.cssopne).parent("li").addClass(i.csscurrent), e.each(function () { s(this).parent("ul").attr(i.datalevel), s(this).find("ul:first").attr(i.datalevel); s(this).hasClass(i.csscurrent) && s(this).find("a:first").hasClass(i.cssopne) ? s(this).find("ul:first").slideDown() : (s(this).find("a:first").removeClass(i.cssopne), s(this).find("ul:first").slideUp()) }) }), c.each(function () { s(this).addClass(i.csscurrent).find("a:first").addClass(i.cssopne), s(this).find("ul:first").show() }) }) } }) }(jQuery);