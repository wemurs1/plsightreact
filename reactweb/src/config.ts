const config = {
    baseApiUrl: 'https://localhost:4000'
};

const currencyFormatter = Intl.NumberFormat('en-gb', {
    style: 'currency',
    currency: 'GBP',
    maximumFractionDigits: 0
});

export default config;
export { currencyFormatter }