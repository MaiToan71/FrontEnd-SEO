import axios from "axios";

import { SERVER_BASE_URL,DEFAULT_LIMIT } from "../utils/constant";

const CategoryAPI = {
    getById: (id : number) =>
    axios.get(`${SERVER_BASE_URL}/api/publish/category/${id}`),
}
export default CategoryAPI;