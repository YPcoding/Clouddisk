import { $t } from "@/plugins/i18n";
import { list } from "@/router/enums";

export default {
  path: "/document",
  redirect: "/document/list",
  meta: {
    icon: "listCheck",
    title: $t("menus.hsList"),
    rank: list
  },
  children: [
    {
      path: "/document/list",
      name: "ListCard",
      component: () => import("@/views/document/list.vue"),
      meta: {
        title: $t("menus.hsListCard"),
        showParent: true
      }
    },
    {
      path: "/document/waterfall",
      name: "Waterfall",
      component: () => import("@/views/document/waterfall.vue"),
      meta: {
        title: $t("menus.hswaterfall")
      }
    }
  ]
} satisfies RouteConfigsTable;
