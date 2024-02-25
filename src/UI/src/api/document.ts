import { http } from "@/utils/http";

type Result = {
  success: boolean;
  data?: {
    /** 列表数据 */
    list: Array<any>;
  };
};

// 参数接口
export interface DocumentPaginationQueryParams {
  /*模糊查询关键字 */
  keyword?: string;

  /*页码 */
  pageNumber: number;

  /*每页大小 */
  pageSize: number;

  /*排序字段；如：Id */
  orderBy?: string;

  /*排序方向：1、Descending 2、Ascending */
  sortDirection?: string;

  /*文档 */
  name?: string;

  /*文档唯一标识 */
  documentId?: number;

  /*父级 */
  parentId?: number;
}

// 响应接口
export interface DocumentPaginationQueryRes {
  /*是否成功 */
  succeeded: boolean;

  /*错误信息数组 */
  errors: Record<string, unknown>[];

  /*错误信息 */
  error: string;

  /*状态码 200成功 0失败 */
  code: number;

  /*消息 */
  message: string;

  /* */
  data: {
    /*当前页 */
    currentPage: number;

    /*总条数 */
    totalItems: number;

    /*总页数 */
    totalPages: number;

    /*有上一页 */
    hasPreviousPage: boolean;

    /*有下一页 */
    hasNextPage: boolean;

    /*返回数据 */
    items: {
      /*唯一标识 */
      id: number;

      /*文档唯一标识 */
      documentId: number;

      /*名称 */
      name: string;

      /*后缀名 */
      extension: string;

      /*别名 */
      aliasName: Record<string, unknown>;

      /*路径 */
      path: string;

      /*字节大小 */
      sizeByte: number;

      /*文件是否保存 */
      isFileSaved: boolean;

      /*父级 */
      parentId: number;

      /*乐观并发标记 */
      concurrencyStamp: string;
    };
  };
}

/** 卡片列表 */
export const getDocumentPaginationQuery = (data?: object) => {
  return http.request<DocumentPaginationQueryRes>(
    "post",
    "https://localhost:7251/api/Document/PaginationQuery",
    {
      data
    }
  );
};
