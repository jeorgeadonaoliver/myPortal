import api from "../../../app/api/api";
import type { AuthType } from "../types/AuthType";


export const verifyOTP = async({uid, otp}: AuthType) => {
    const response = await api.post('auth/otp', { uid, otp});
    return response.data;
};