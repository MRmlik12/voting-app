import { ParsedUrlQuery } from "querystring";

export interface VotingParams extends ParsedUrlQuery {
  itemIndex?: string;
}
