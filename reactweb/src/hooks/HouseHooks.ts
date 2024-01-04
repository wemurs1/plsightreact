import { House } from "../types/house";
import config from "../config";
import axios, { AxiosError } from "axios";
import { useQuery } from "react-query";

const useFetchHouses = () => {
    return useQuery<House[], AxiosError>("houses", () =>
        axios.get(`${config.baseApiUrl}/houses`).then(resp => resp.data)
    );
}

const useFetchHouse = (id: number) => {
    return useQuery<House, AxiosError>("houses", () =>
        axios.get(`${config.baseApiUrl}/house/${id}`).then(resp => resp.data)
    );
}

export default useFetchHouses;
export { useFetchHouse }